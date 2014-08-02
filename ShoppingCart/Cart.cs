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

        decimal subtotal = 0;
        string discount = string.Empty;

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void ApplyDiscount(Discount discount)
        {
            _appliedDiscount = discount;
        }

        public decimal ProcessCart()
        {
            subtotal = _products.Sum(a => a.Price);
            discount = string.Empty;
            
            if (_appliedDiscount.Amount != 0)
            {
                switch (_appliedDiscount.Type)
                {
                    case "percentage":
                        discount = _appliedDiscount.Amount + "%";
                        subtotal = subtotal * (1 + (_appliedDiscount.Amount / 100));
                        break;

                    case "fixed":

                        discount = _appliedDiscount.Amount.ToString("C");
                        subtotal = subtotal - _appliedDiscount.Amount;
                        break;

                    default:
                        discount = "R$ 0,00";
                        break;
                }
            }
            else
            {
                discount = "R$ 0,00";
            }
            

            try
            {
                return Convert.ToDecimal(subtotal);
            }
            catch(Exception e)
            {
                throw new System.Exception("Não foi possível processar o carrinho de compras. Erro: " + e.Message);
            }

        }

        public void PrintSummary()
        {
            ProcessCart();

            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var cartProduct in _products)
            {
                Console.WriteLine(cartProduct.Id + " " + cartProduct.Name + "            " + cartProduct.Price.ToString("C"));
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Descontos:            -" + discount);
            Console.WriteLine("Total:                " + subtotal.ToString("C"));
            Console.Read();
        }


    }
}
