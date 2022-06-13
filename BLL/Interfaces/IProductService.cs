using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        Product Get(string name);
        IReadOnlyCollection<Product> List();
        void Add(Product catalog);
        void Update(Product catalog);
        void Delete(string name);
    }
}
