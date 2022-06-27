namespace BLL.Entities
{
    public class Product: BaseEntity
    {
        public Product(string name)
        {
            if (name is null || name.Length > 50)
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
        }

        public string Name { get; init; }
        public Uri Image { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public uint Amount { get; set; }
    }
}
