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
        public string FilePath = "vendingmachine.csv";

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
                        Product p = productItem(line);
                        string location = line.Split('|')[0];

                        inventory.Add(location, )

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
        private static Product productItem(string line)
        {
            Product productItem;

            string[] fields = line.Split('|');

            
            string name = fields[1];
            decimal price = decimal.Parse(fields[2]);

            for(int i = 0; i < 5; i++)
            {
                if (Location.StartsWith("A"))
                {
                    productItem = new ChipItem(name, price, location);
                }
                else if (location.StartsWith("B"))
                {
                    productItem = new CandyItem(name, price, location);
                }
                else if (location.StartsWith("C"))
                {
                    productItem = new BeverageItem(name, price, location);
                }
                else if (location.StartsWith("D"))
                {
                    productItem = new GumItem(name, price, location);
                }
            }
           

            productItem.Location = fields[0];
            productItem.Name = fields[1];
            productItem.Price = fields[2];


            return productItem;
        }
    }
}
