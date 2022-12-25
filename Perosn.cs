using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brutto_netto
{
    internal class Person
    {

        internal int Id { get; set; }
        internal DateTime Date { get; set; }
        internal decimal Age
        {
            get
            {
                DateTime today = DateTime.Now;
                decimal days = (decimal)(today - Date).TotalDays;
                decimal years = Math.Round(days / 365.242199m, 2);
                return years;
            }

        }
        internal bool IsStudent { get; set; }
        internal int ContractType { get; set; }
        internal decimal PerHour { get; set; }
        internal decimal Salary { get; set; }
        internal decimal HoursWorked { get; set; }

    }

}
