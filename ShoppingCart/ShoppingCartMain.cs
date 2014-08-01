using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCartMain
    {

        private IList<Product> productList = new List<Product>();
        private IList<Discount> discountList = new List<Discount>();

        public void LoadData()
        {
            discountList = FileReader.LoadDiscounts();
            productList = FileReader.LoadProducts();
        }

        public Product GetProductById(int id)
        {
            return productList.FirstOrDefault(a => a.Id == id);
        }

        public Discount GetDiscountByCode(string code)
        {
            return discountList.FirstOrDefault(a => a.Code.Equals(code,StringComparison.InvariantCultureIgnoreCase));
        }

        
    }
}
