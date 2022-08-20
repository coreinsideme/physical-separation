using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Entities;


namespace BLL.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public Product GetProduct(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            return _repository.GetProduct(name);
        }

        public IReadOnlyCollection<Product> List(int id, int pageSize, int pageNumber)
        {
            return _repository.List(id, pageSize, pageNumber);
        }

        public void Add(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            Upsert(product);
        }

        public void Update(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);
            Upsert(product);
        }

        public void Delete(int id)
        {
            ArgumentNullException.ThrowIfNull(id);
            _repository.Delete(id);
        }

        private void Upsert(Product product)
        {
            var duplicate = _repository.GetProduct(product.Name);

            if (duplicate is not null) { _repository.Update(product); }

            _repository.Add(product);
        }
    }
}
