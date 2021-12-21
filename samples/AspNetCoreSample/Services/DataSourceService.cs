using System;
using System.Linq;
using System.Threading.Tasks;
using DSDemo.Entities;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace DSDemo.Services
{
    public class DataSourceService
    {
        private readonly static Random _random = new Random();
        private readonly static DataSource[] DataSource = Enumerable.Range(1, 40).Select(x => new DataSource(x, $"Item{x:D2}", _random.Next(5, 20))).ToArray();

        public Task<DataSourceResult> GetDataSourceAsync(DataSourceRequest request)
        {
            return DataSource.AsQueryable().ToDataSourceResultAsync(request);
        }

        public Task<DataSource> UpdateDataSourceAsync(int id, DataSource input)
        {
            var entity = DataSource.FirstOrDefault(p => p.Id == id);
            if(entity != null)
            {
                entity.Name = input.Name;
                entity.Value = input.Value;
            }
            return Task.FromResult(entity);
        }
    }
}
