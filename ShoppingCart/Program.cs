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
        static ShoppingCartMain shoppingCartMain = new ShoppingCartMain();
        static Cart cart = new Cart();
        private static bool isProductLoopActive = true;
        private static bool isDiscountLoopActive = true;

        static void Main(string[] args)
        {
            shoppingCartMain.LoadData();

            Console.WriteLine("-- Bem-vindo ao Carrinho de Compras!");
            Console.WriteLine("");

            do
            {
                ManageProduct();
            } while (isProductLoopActive == true);

            do
            {
                ManageDiscount();
            } while (isDiscountLoopActive == true);


            cart.Summary();


            
        }

        public static void ManageProduct()
        {
            int productId;

            Console.WriteLine("-> Digite o ID do produto que deseja adicionar:");
            var readProductId = Console.ReadLine();
            int.TryParse(readProductId, out productId);

            var product = shoppingCartMain.GetProductById(productId);

            if (product == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }
            else
            {
                cart.Add(product);
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

        public static void ManageDiscount()
        {
            Console.WriteLine("Deseja adicionar um cupom de desconto [S/n]?");
            string applyDiscount = Console.ReadLine();

            if (applyDiscount != null && applyDiscount.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Digite o código do cupom:");
                string coupom = Console.ReadLine();

                var discount = shoppingCartMain.GetDiscountByCode(coupom);

                if (discount != null)
                {
                    cart.ApplyDiscount(discount);
                    Console.WriteLine("O desconto foi aplicado!");
                    isDiscountLoopActive = false;
                }
                else
                {
                    Console.WriteLine("Coupom Inválido");
                }
            }
        }
    }
}
