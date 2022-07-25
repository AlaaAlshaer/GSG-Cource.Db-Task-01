using Product.API.Models;
using System.Collections.Generic;

namespace Product.API.Services
{
    public interface IProductService
    {
        List<ProductEntity> GetAll();
        List<ProductEntity> Delete(int id);
        ProductEntity Get(int id);
        List<ProductEntity> Create(string name, float cost, float price);
        List<ProductEntity> Update(int id,string name, float cost, float price);
    }
}