using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ICatalogRepository
    {
        Catalog Get(string name);
        IReadOnlyCollection<Catalog> List();
        void Add(Catalog catalog);
        void Update(Catalog catalog);
        void Delete(string name);
    }
}
