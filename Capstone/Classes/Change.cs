using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        public int Nickels { get; private set; }

        public int Dimes { get; private set; }

        public int Quarters { get; private set; }

        public decimal Total { get; }

        public Change(decimal total)
        {
            this.Total = total;

            decimal changeTotal = this.Total;

            Quarters = (int)(changeTotal / 0.25M);
            changeTotal -= Quarters * 0.25M;

            Dimes = (int)(changeTotal / 0.10M);
            changeTotal -= Dimes * 0.10M;

            Nickels = (int)(changeTotal / 0.05M);
            changeTotal -= Nickels * 0.05M;
        }

               
    }
}
