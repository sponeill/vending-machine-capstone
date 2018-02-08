using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        public int Nickels { get; }

        public int Dimes { get; }

        public int Quarters { get; }

        public decimal Total { get; }

        public Change result (decimal total)
        {
          
        }
        public string GetChange(decimal total)
        {
            string result = "";

        Quarters = total / 25;
            int remainder = total % 25;

        Dimes = remainder / 10;
            remainder = remainder % 10;

            Nickels = remainder / 5;

            result = ($"{Quarters} Quarters, {Dimes} Dimes, {Nickels} Nickels");

            return result;
        }
        
    }
}
