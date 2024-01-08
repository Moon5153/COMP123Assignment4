using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123Assignment4
{
    public static class DataStore
    {
        public static Catalog Load(string filePath)
        { 
            IEnumerable<string> catalogList = File.ReadAllLines(filePath); 
            Catalog catalog = new Catalog();
            foreach (string line in catalogList) 
            {
                Product product = new Product(); 
                string[] values = line.Split('\t');
                product.Name = values[0];
                product.Department = (Department)Enum.Parse(typeof(Department), values[1]); 
                product.Price = Convert.ToDecimal(values[2]);
                catalog.Add(product); 
            } 
            return catalog;
        }
        public static void Save(Catalog catalog, string filePath)
        { 
            if (File.Exists(filePath) == true) 
            { 
                File.Delete(filePath);
            } 
            IEnumerable<Product> products = catalog.GetAllProducts();
            using (StreamWriter writer = new StreamWriter(filePath))
            { 
                foreach (Product product in products)
                { 
                    string line = $"{product.Name}\t{product.Department.ToString()}\t{product.Price.ToString()}";
                    writer.WriteLine(line); 
                }
            } 
        }

    }
}
