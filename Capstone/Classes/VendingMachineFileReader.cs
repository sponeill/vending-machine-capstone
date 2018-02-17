using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineFileReader
    {
        private const int Col_SlotId = 0;
        private const int Col_Name = 1;
        private const int Col_Price = 2;
        private const int Default_Quantity = 5;

        private string FilePath { get; set; }

        public VendingMachineFileReader(string filePath)
        {
            FilePath = filePath;
        }

        public Dictionary<string, List<Product>> GetInventory()
        {
            Dictionary<string, List<Product>> inventory = new Dictionary<string, List<Product>>();

            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        List<Product> products = GetProducts(line);
                        string location = line.Split('|')[Col_SlotId];
                        inventory.Add(location, products);

                    }
                }               
            }
            catch(IOException ex)
            {
                Console.WriteLine("Something went wrong while opening the file, please try again!");
                Console.WriteLine(ex.Message);
            }

            return inventory;
        }
       
        private static List<Product> GetProducts(string line)
        {            
            List<Product> products = new List<Product>();

            string[] fields = line.Split('|');

            string location = fields[Col_SlotId];
            string name = fields[Col_Name];
            decimal price = decimal.Parse(fields[Col_Price]);

            for(int i = 0; i < Default_Quantity; i++)
            {
                Product productItem;

                if (location.StartsWith("A"))
                {
                    productItem = new ChipItem(name, price, location);
                    products.Add(productItem);
                }
                else if (location.StartsWith("B"))
                {
                    productItem = new CandyItem(name, price, location);
                    products.Add(productItem);
                }
                else if (location.StartsWith("C"))
                {
                    productItem = new BeverageItem(name, price, location);
                    products.Add(productItem);
                }
                else if (location.StartsWith("D"))
                {
                    productItem = new GumItem(name, price, location);
                    products.Add(productItem);
                }                
            }

            return products;
        }

        
    }
}
