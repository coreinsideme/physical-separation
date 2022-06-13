using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Entities;

namespace DAL.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public Product Get(string name)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Product> List()
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}
