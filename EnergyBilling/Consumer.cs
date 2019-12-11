using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Refactor exercise 1
namespace EnergyBilling
{
    public class Consumer
    {
        public enum ConsumerType {  Individual = 0, Organisation = 1, GovernmentOrganisation = 2 };

        public string Id { get; set; }
        public string Name { get; set; }
        public string BillingAddress { get; set; }
        public decimal BilledAmount { get; set; }
        public uint TotalUtilizedUnits { get; set; }
        public uint AvgUnitsUtilizedPerDay { get; set; }
        public int BilledMonth { get; set; }
        public ConsumerType Type { get; set; }
        public void CalculateBill()
        {
            Id = Guid.NewGuid().ToString();

            TotalUtilizedUnits = AvgUnitsUtilizedPerDay * (uint)DateTime.Now.Day;

            if (TotalUtilizedUnits < 100)
                BilledAmount = TotalUtilizedUnits;
            else if (TotalUtilizedUnits < 200)
                BilledAmount = TotalUtilizedUnits * 1.2m;
            else if (TotalUtilizedUnits < 300)
                BilledAmount = TotalUtilizedUnits * 1.4m;
            else if (TotalUtilizedUnits < 500)
                BilledAmount = TotalUtilizedUnits * 1.5m;

            if (Type == ConsumerType.GovernmentOrganisation)
                BilledAmount /= 2.0m;
            if (Type == ConsumerType.Organisation)
                BilledAmount *= 1.5m;
        }

        public void PrintBill()
        {
            BilledMonth = DateTime.Now.Month;
            Console.WriteLine($"-----------------  Energy Bill ({ GetMonth(BilledMonth)}) -------------------------");
            Console.WriteLine($"Consumer Id:{Id}         Type:{Type}");
            Console.WriteLine($"Consumer Name:{Name}");
            Console.WriteLine($"Address:{BillingAddress}");
            Console.WriteLine($"....................................................................");
            Console.Write($"Units consumed:{TotalUtilizedUnits}    Per day consumption:{AvgUnitsUtilizedPerDay}");
            Console.WriteLine();
            Console.WriteLine($"Billed amount: {BilledAmount} GBP");
            Console.WriteLine($"--------------------------------------------------------------------");
        }

        private string GetMonth(int month)
        {
            string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return MonthNames[month - 1];
        }
    }
}
