using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Entities;

namespace DAL.Repositories
{
    public class CatalogRepository: ICatalogRepository
    {
        public Catalog Get(string name)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Catalog> List()
        {
            throw new NotImplementedException();
        }

        public void Add(Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public void Update(Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}
