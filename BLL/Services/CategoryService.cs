using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Interfaces;
using BLL.Entities;

namespace BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            this._repository = repository;
        }

        public Category Get(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            return _repository.Get(name);
        }

        public IReadOnlyCollection<Category> List()
        {
            return _repository.List();
        }

        public void Add(Category catalog)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            Upsert(catalog);
        }

        public void Update(Category catalog)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            Upsert(catalog);
        }

        public void Delete(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            _repository.Delete(name);
        }

        private void Upsert(Category catalog)
        {
            var duplicate = _repository.Get(catalog.Name);

            if (duplicate is not null) { _repository.Update(catalog); }

            _repository.Add(catalog);
        }
    }
}
