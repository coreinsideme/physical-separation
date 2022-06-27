namespace Web.Dtos
{
    public record CategoryDto
    {
        public string Name { get; init; }
        public string Image { get; init; }
        public int ParentCategoryId { get; init; }
    }
}
