using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasket.Models
{
    public class MyBasketRepository
    {

        MyBasketDataContext _myBasketDataContext = new MyBasketDataContext();

        internal List<Product> GetProducts()
        {
            return _myBasketDataContext.Products.ToList();
        }

        internal List<Brand> GetBrands()
        {
            return _myBasketDataContext.Brands.ToList();
        }

        internal List<Category> GetCategories()
        {
            return _myBasketDataContext.Categories.ToList();
        }

        internal List<Product> GetProductsByBrandId(int BrandId)
        {
            return _myBasketDataContext.Products.ToList().FindAll(product => product.BrandID == BrandId);
        }

        internal List<Product> GetProductsByCategoryId(int CategoryId)
        {
            return _myBasketDataContext.Products.ToList().FindAll(product => product.CategoryID == CategoryId);
        }

        internal Product GetProductById(int ProductId)
        {
            return _myBasketDataContext.Products.ToList().Find(product => product.ID == ProductId);
        }

    }
}