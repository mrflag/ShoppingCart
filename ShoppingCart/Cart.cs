using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Cart
    {
        private IList<Product> _products = new List<Product>();
        private Discount _appliedDiscount = new Discount();

        public IList<Product> Products { get { return _products; } }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void ApplyDiscount(Discount discount)
        {
            _appliedDiscount = discount;
        }

        public Discount GetDiscount()
        {
            return _appliedDiscount;
        }

        public void Summary()
        {
            //foreach (var cartProduct in cart.Products)
            //{
            //    Console.WriteLine(cartProduct.Id + " " + cartProduct.Name + "                                    " + cartProduct.Price);
            //    Console.WriteLine("");
            //    Console.WriteLine("");
            //    Console.WriteLine("Descontos:                                    " + cart.GetDiscount().Amount);
            //}

        }
    }
}
