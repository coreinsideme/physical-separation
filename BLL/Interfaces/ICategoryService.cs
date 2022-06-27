using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        Category Get(string name);
        IReadOnlyCollection<Category> List();
        void Add(Category catalog);
        void Update(Category catalog);
        void Delete(int id);
    }
}
