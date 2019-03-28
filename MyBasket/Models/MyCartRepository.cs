using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MyBasket.Models
{
    public class MyCartRepository
    {
        MyBasketDataContext myBasketDataContext = new MyBasketDataContext();

        public void AddToCart(int ProductID)
        {
            Product MyCartproduct = myBasketDataContext.Products.ToList().Find(product => product.ID == ProductID);
        }

    }
}