using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brutto_netto
{
    internal class GetSet
    {
        List<Person> PersonsList = new List<Person>();
        internal void CreatePerson(int id, DateTime date, bool isStudent, int contractType, decimal perHour, decimal salary, decimal hoursWorked)
        {
            Person person = new Person()
            {
                Id = id,
                Date = date,
                IsStudent = isStudent,
                ContractType = contractType,
                PerHour = perHour,
                Salary = salary,
                HoursWorked = hoursWorked
            };

            PersonsList.Add(person);
        }

        internal Person GetPerson()
        {
            return PersonsList[0];
        }
    }
}
