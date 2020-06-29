using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProductSearch.Models;

namespace ProductSearch.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _ctx;

        public ProductRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetAll()
        {
            return _ctx.Products;
        }

        public Product GetSingle(int id)
        {
            return _ctx.Products.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Product> GetBySearchDesc(string searchQuery)
        {
            return _ctx.Products.Where(x => x.products_description.Contains(searchQuery));
        }

        public Product Add(Product toAdd)
        {
            _ctx.Products.Add(toAdd);
            return toAdd;
        }

        public Product Update(Product toUpdate)
        {
            _ctx.Products.Update(toUpdate);
            return toUpdate;
        }

        public void Delete(Product toDelete)
        {
            _ctx.Products.Remove(toDelete);
        }

        public int Save()
        {
            return _ctx.SaveChanges();
        }
    }
}