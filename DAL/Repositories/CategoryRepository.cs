using BLL.Interfaces;
using BLL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ICommandExecutor _commandExecutor;

        public CategoryRepository(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
            CreateTable();
        }

        public Category Get(string name)
        {
            var command = $"SELECT * from categories WHERE name = '{name}'";
            return _commandExecutor.ExecuteSelect<Category>(command);
        }

        public IReadOnlyCollection<Category> List()
        {
            var command = $"SELECT * from categories";
            return _commandExecutor.ExecuteSelect<List<Category>>(command).AsReadOnly();
        }

        public void Add(Category category)
        {
            var command = 
                @$"
                    INSERT INTO categories
                    VALUES ('{category.Name}', '{category.Image.AbsoluteUri}', '{category.ParentCategoryId}')
                ";
            _commandExecutor.Execute(command);
        }

        public void Update(Category category)
        {
            var command =
                @$"
                    UPDATE categories 
                    SET image = {category.Image}, parentCategory = {category.Image}
                    WHERE name = '{category.Name}'
                ";
            _commandExecutor.Execute(command);
        }

        public void Delete(int id)
        {
            var command = $"DELETE from categories WHERE id = {id}";
            _commandExecutor.Execute(command);
        }

        private void CreateTable()
        {
            var command =
                @"
                    CREATE TABLE categories (
                        id integer,
                        name text,
                        image text,
                        categoryName text
                    )
                ";
            _commandExecutor.Execute(command);
        }
    }
}
