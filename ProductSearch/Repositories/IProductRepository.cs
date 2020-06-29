using System.Collections.Generic;
using ProductSearch.Models;

namespace ProductSearch.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetSingle(int id);
        IEnumerable<Product> GetBySearchDesc(string searchQuery);
        Product Add(Product toAdd);
        Product Update(Product toUpdate);
        void Delete(Product toDelete);
        int Save();
    }
}