using BLL.Interfaces;
using BLL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ICommandExecutor _commandExecutor;

        public ProductRepository(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
            CreateTable();
        }

        public Product Get(string name)
        {
            var command = $"SELECT * from products WHERE name = '{name}'";
            return _commandExecutor.ExecuteSelect<Product>(command);
        }

        public IReadOnlyCollection<Product> List()
        {
            var command = $"SELECT * from products";
            return _commandExecutor.ExecuteSelect<List<Product>>(command).AsReadOnly();
        }

        public void Add(Product product)
        {
            var command =
                @$"
                    INSERT INTO products
                    VALUES ('{product.Name}', '{product.Image}', '{product.Category}', '{product.Description}', '{product.Price}', '{product.Amount}')
                ";
            _commandExecutor.Execute(command);
        }

        public void Update(Product product)
        {
            var command =
                @$"
                    UPDATE products 
                    SET image = {product.Image}, category = {product.Category}, description = {product.Description}, price = {product.Price}, amount = {product.Amount}
                    WHERE name = '{product.Name}'
                ";
            _commandExecutor.Execute(command);
        }

        public void Delete(string name)
        {
            var command = $"DELETE from categories WHERE name = {name}";
            _commandExecutor.Execute(command);
        }

        private void CreateTable()
        {
            var command =
                @"
                    CREATE TABLE products (
                        name text,
                        image text,
                        category text,
                        description text,
                        price real,
                        amount integer
                    )
                ";
            _commandExecutor.Execute(command);
        }
    }
}
