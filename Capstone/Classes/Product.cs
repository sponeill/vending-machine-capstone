using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
   public class Product
    {
        public string Name { get; }

        public decimal Price { get; }

        public string Location { get; }

        public Product(string name, decimal price, string location)
        {
            this.Name = name;
        }

        public virtual void Consume()
        {

        }
       
    }
}
