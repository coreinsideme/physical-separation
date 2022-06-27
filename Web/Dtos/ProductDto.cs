namespace Web.Dtos
{
    public record ProductDto
    {
        public string Name { get; init; }
        public string Image { get; init; }
        public int CategoryId { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public uint Amount { get; init; }
    }
}
