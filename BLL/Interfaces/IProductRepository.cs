using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IProductRepository
    {
        Product Get(string name);
        IReadOnlyCollection<Product> List();
        void Add(Product catalog);
        void Update(Product catalog);
        void Delete(string name);
    }
}
