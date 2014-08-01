using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ShoppingCart
{
    public static class FileReader
    {
        private static IList<T> LoadObjectFromFile<T>(string fileName)
        {
            var fileText = File.ReadAllText(@"./Data/" + fileName + ".json");

            var listObjects = JsonConvert.DeserializeObject<IList<T>>(fileText);

            return listObjects;
        }

        public static IList<Discount> LoadDiscounts()
        {
            var list = LoadObjectFromFile<Discount>("discounts");
            return list;
        }

        public static IList<Product> LoadProducts()
        {
            var list = LoadObjectFromFile<Product>("products");
            return list;
        }
    }
}