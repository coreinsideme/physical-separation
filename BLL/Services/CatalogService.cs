using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Interfaces;
using BLL.Entities;

namespace BLL.Services
{
    public class CatalogService: ICatalogService
    {
        private readonly ICatalogRepository _repository;

        public CatalogService(ICatalogRepository repository)
        {
            this._repository = repository;
        }

        public Catalog Get(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            return _repository.Get(name);
        }

        public IReadOnlyCollection<Catalog> List()
        {
            return _repository.List();
        }

        public void Add(Catalog catalog)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            Upsert(catalog);
        }

        public void Update(Catalog catalog)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            Upsert(catalog);
        }

        public void Delete(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            _repository.Delete(name);
        }

        private void Upsert(Catalog catalog)
        {
            var duplicate = _repository.Get(catalog.Name);

            if (duplicate is not null) { _repository.Update(catalog); }

            _repository.Add(catalog);
        }
    }
}
