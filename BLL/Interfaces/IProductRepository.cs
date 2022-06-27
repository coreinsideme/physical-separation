using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IProductRepository
    {
        Product Get(string name);
        IReadOnlyCollection<Product> List(int id, int pageSize, int pageNumber);
        void Add(Product catalog);
        void Update(Product catalog);
        void Delete(int id);
    }
}
