using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(string name);
        IReadOnlyCollection<Product> List(int id, int pageSize, int pageNumber);
        void Add(Product catalog);
        void Update(Product catalog);
        void Delete(int id);
    }
}
