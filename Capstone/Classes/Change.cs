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

        public Change(decimal total)
        {

        }

        Dictionary<int, string> change = new Dictionary<int, string>()
            {
                {5, "Nickel" }, {10, "Dime"}, {25, "Quarter"}
            };

        string result = "";

        int[] places = { 25, 10, 5 };

            foreach (int place in places)
            {
                result += change[place];
                total -= place;
            }

            if (total > 0)
            {
                result += change[total];
            }
    }
}
