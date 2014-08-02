using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ShoppingCart
{
    public static class DataReader
    {
        private static IList<T> LoadObjectFromJsonFile<T>(string fileName)
        {
            var fileText = File.ReadAllText(@"./Data/" + fileName + ".json");

            var listObjects = JsonConvert.DeserializeObject<IList<T>>(fileText);

            return listObjects;
        }

        public static IList<Discount> LoadDiscounts()
        {
            var list = LoadObjectFromJsonFile<Discount>("discounts");
            return list;
        }

        public static IList<Product> LoadProducts()
        {
            var list = LoadObjectFromJsonFile<Product>("products");
            return list;
        }
    }
}