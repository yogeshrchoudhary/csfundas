using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyBillingConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            EnergyBilling.Consumer consumer = new EnergyBilling.Consumer
            {
                AvgUnitsUtilizedPerDay = (uint)(new Random(DateTime.Now.Second).Next(10, 20)),
                Name = "John Doe",
                BillingAddress = "12E, Stannard way, Chelmsford, Burlingtonshire, UA1 43B, United Kingdom",
                Type = EnergyBilling.Consumer.ConsumerType.Individual
            };

            consumer.CalculateBill();
            consumer.PrintBill();
        }
    }
}
