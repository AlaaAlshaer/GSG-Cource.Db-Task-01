using Product.API.Data;
using Product.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        //readonly : when we intilize the instance can not change it
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ProductEntity> GetAll()
        {
            return _db.Products.ToList();
        }

        public List<ProductEntity> Delete (int id)
        {
            var product =  _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return _db.Products.ToList();
        }

        public ProductEntity Get(int id)
        {
            var product = _db.Products.Find(id);
            return product;
        }

        public List<ProductEntity> Create(string name,float cost, float price)
        {

            var product = new ProductEntity
            {
                Cost = cost,
                Price = price,
                Name = name
            };
            _db.Products.Add(product);
            _db.SaveChanges();
            return _db.Products.ToList();
        }

        public List<ProductEntity> Update(int id, string name, float cost, float price)
        {
            var product = _db.Products.Find(id);

            product.Price = price;
            product.Name = name;
            product.Cost = cost;

            _db.Products.Update(product);
            _db.SaveChanges();
            return _db.Products.ToList();
        }
    }

}
