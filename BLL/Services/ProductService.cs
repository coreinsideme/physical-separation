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

        public Product Get(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            return _repository.Get(name);
        }

        public IReadOnlyCollection<Product> List()
        {
            return _repository.List();
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

        public void Delete(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            _repository.Delete(name);
        }

        private void Upsert(Product product)
        {
            var duplicate = _repository.Get(product.Name);

            if (duplicate is not null) { _repository.Update(product); }

            _repository.Add(product);
        }
    }
}
