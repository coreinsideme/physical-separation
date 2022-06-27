using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ICategoryRepository
    {
        Category Get(string name);
        IReadOnlyCollection<Category> List();
        void Add(Category catalog);
        void Update(Category catalog);
        void Delete(int id);
    }
}
