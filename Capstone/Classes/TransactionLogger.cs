using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Capstone.Classes
{
    public class TransactionLogger
    {
        private string Filepath = "Log.txt";
        private string SalesReport = "SalesReport.txt";

        public TransactionLogger(string filePath, string salesReport)
        {
            Filepath = filePath;
            SalesReport = salesReport;
        }

        public void RecordDeposit(decimal amount, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Filepath, true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY {amount}  {finalBalance}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void RecordPurchase(string slot, string product, decimal initialBalance, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Filepath, true))
                {
                    sw.WriteLine($"{DateTime.Now} {product} {slot} {initialBalance} {finalBalance} ");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RecordCompleteTransaction(decimal remainingBalance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(SalesReport, true))
                {
                    sw.WriteLine($" ");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
