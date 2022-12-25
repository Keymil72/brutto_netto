using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brutto_netto
{
    public class Tax
    {
        public decimal Min = 30000;
        public decimal Max = 120000;
        public decimal MinPercent = 0;
        public decimal MidPercent = 12;
        public decimal MaxPercent = 32;
        public decimal PensionTax = 9.75m;
        public decimal RentalTax = 1.5m;
        public decimal SicknessTax = 2.45m;
        public decimal SocialTax = 13.71m;
        public decimal DeducitibleTax = 250;
        public decimal HealthTax = 9;
    }
}
