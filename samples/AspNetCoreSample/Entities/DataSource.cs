namespace DSDemo.Entities
{
    public class DataSource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public DataSource(int id, string name, int value)
        {
            this.Id = id;
            Name = name;
            Value = value;
        }
    }
}
