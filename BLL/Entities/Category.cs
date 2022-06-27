namespace BLL.Entities
{
    public class Category: BaseEntity
    {
        public Category(string name)
        {
            if (name is null || name.Length > 50)
            {
                throw new ArgumentException(nameof(name));
            }

            Name = name;
        }

        public string Name { get; init; }
        public Uri Image { get; set; }
        public int  ParentCategoryId { get; set; }
    }
}
