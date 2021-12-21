using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DSDemo.Models;
using DSDemo.Services;
using System.Text.Json;
using Telerik.DataSource;
using DSDemo.Entities;
using Kendo.Mvc.Extensions;
using DataSourceRequest = Telerik.DataSource.DataSourceRequest;
using DataSourceRequestAttribute = Telerik.DataSource.Mvc.Binder.DataSourceRequestAttribute;

namespace DSDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataSourceService _dataSourceService;
        private readonly static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions(new JsonOptions().JsonSerializerOptions)
        {
            PropertyNamingPolicy = null
        };

        public HomeController(DataSourceService dataSourceService)
        {
            _dataSourceService = dataSourceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> DataSourceAsync([DataSourceRequest] DataSourceRequest dsRequest)
        {
            return Json(await _dataSourceService.GetDataSourceAsync(dsRequest), JsonSerializerOptions);
        }

        [HttpPut]
        public async Task<IActionResult> DataSourceAsync(DataSourceModel model)
        {
            var dsr = new DataSourceResult(){ Total = 1, AggregateResults = null };
            if(ModelState.IsValid)
            {
                var entity = new DataSource(model.Id, model.Name, model.Value);
                var result = await _dataSourceService.UpdateDataSourceAsync(model.Id, entity);
                if(result != null)
                {
                    dsr.Data = new DataSourceModel[] { new DataSourceModel { Id = result.Id, Name = $"{result.Name}-Modify", Value = result.Value} }.AsGenericEnumerable();
                }
            }
            else
            {
                dsr.Data = new DataSourceModel[0].AsGenericEnumerable();
                dsr.Errors = ModelState.SerializeErrors();
            }
            if(dsr.Data == null) return StatusCode(404);
            return Json(dsr, JsonSerializerOptions);
        }
    }
}
