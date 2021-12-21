using System.ComponentModel.DataAnnotations;

namespace DSDemo.Models
{
    public class DataSourceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Value { get; set; }
    }
}
