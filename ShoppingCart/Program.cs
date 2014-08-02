using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;

namespace ShoppingCart
{
    class Program
    {
        private static ShoppingCartHelper _shoppingCartHelper = new ShoppingCartHelper();
        private static Cart _cart = new Cart();
        private static bool isProductLoopActive = true;
        private static bool isDiscountLoopActive = true;

        static void Main(string[] args)
        {
            _shoppingCartHelper.LoadData();

            Console.WriteLine("-- Bem-vindo ao Carrinho de Compras!");
            Console.WriteLine("");

            do
            {
                ProductLoop();
            } while (isProductLoopActive == true);

            do
            {
                DiscountLoop();
            } while (isDiscountLoopActive == true);


            _cart.PrintSummary();
        }

        public static void ProductLoop()
        {
            int productId;

            Console.WriteLine("-> Digite o ID do produto que deseja adicionar:");
            var readProductId = Console.ReadLine();
            int.TryParse(readProductId, out productId);

            var product = _shoppingCartHelper.GetProductById(productId);

            if (product == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }
            else
            {
                _cart.Add(product);
                Console.WriteLine("O produto '" + product.Name + "' foi adicionado!");
                Console.WriteLine("");


                Console.WriteLine("Deseja adicionar outro produto [S/n]?");
                string addAnotherProduct = Console.ReadLine();

                if (addAnotherProduct != null && addAnotherProduct.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    isProductLoopActive = false;
                }
                else
                {
                    return;
                }
            }
        }

        public static void DiscountLoop()
        {
            Console.WriteLine("Deseja adicionar um cupom de desconto [S/n]?");
            string applyDiscount = Console.ReadLine();

            if (applyDiscount != null && applyDiscount.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Digite o código do cupom:");
                string coupom = Console.ReadLine();

                var discount = _shoppingCartHelper.GetDiscountByCode(coupom);

                if (discount != null)
                {
                    _cart.ApplyDiscount(discount);
                    Console.WriteLine("O desconto foi aplicado!");
                    isDiscountLoopActive = false;
                }
                else
                {
                    Console.WriteLine("Coupom Inválido");
                }
            }
            else
            if (applyDiscount != null && applyDiscount.Equals("N", StringComparison.InvariantCultureIgnoreCase))
            {
                isDiscountLoopActive = false;
            }
        }
    }
}
