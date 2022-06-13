namespace BLL.Entities
{
    public class Catalog
    {
        public Catalog(string name)
        {
            if (name is null || name.Length > 50)
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
        }

        public string Name { get; init; }
        public Uri Image { get; set; }
        public string ParentCategory { get; set; }
    }
}
