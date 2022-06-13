using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ICatalogService
    {
        Catalog Get(string name);
        IReadOnlyCollection<Catalog> List();
        void Add(Catalog catalog);
        void Update(Catalog catalog);
        void Delete(string name);
    }
}
