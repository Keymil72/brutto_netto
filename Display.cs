using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brutto_netto
{
    internal class Display
    {
        GetSet gs = new GetSet();
        Calculate calc = new Calculate();
        DateTime Date;
        bool IsStudent;
        int ContractType;
        decimal PerHour;
        decimal Salary;
        decimal HoursWorked;

        internal void WelcomeScreen()
        {
            Console.WriteLine("***Program obliczający wynagrodzenie***");
            Console.WriteLine("Zaczynajmy!!! ;)");
            Console.ReadLine();

            DateScreen();
        }

        internal void DateScreen() 
        {
            string x= "s";
            DateTime date;
            while (!DateTime.TryParse(x, out date))
            {
                Console.Clear();
                Console.WriteLine("Podaj date urodzenia (przykład 24.04.2004)");
                x = Console.ReadLine();
            }
            Date = date;
            IsStudentScreen();
            
        }

        internal void IsStudentScreen()
        {
            Console.Clear();
            Console.WriteLine("Czy osoba dalej ma status ucznia/studenta?");
            Console.WriteLine("Odpowiedź tak/nie");
            string x = Console.ReadLine();
            bool status;
            if (x.ToLower().Equals("tak") || x.ToLower().Equals("t"))
            {
                status = true;
            }
            else
            {
                status = false;
            }
            IsStudent = status;
            ContractTypeScreen();
        }

        internal void ContractTypeScreen()
        {
            string key = "";
            while (key != "1" && key != "2")
            {
                Console.Clear();
                Console.WriteLine("Wybierz z listy klikając cyfrę na klawiaturze");
                Console.WriteLine("1. Umowa o pracę");
                Console.WriteLine("2. Umowa zlecenie");
                key = Console.ReadLine();
                Console.WriteLine(key);
            }
            if (key == "1")
            {
                Console.WriteLine("1");
                int.TryParse(key, out ContractType);
                SalaryScreen();
            }else
            {
                Console.WriteLine("2");
                int.TryParse(key, out ContractType);
                PerHourScreen();
            }
        }

        internal void PerHourScreen()
        {
            string x = "";
            decimal perHour;
            while (!decimal.TryParse(x, out perHour))
            {
                Console.Clear();
                Console.WriteLine("Podaj kwotę brutto na godzinę");
                x = Console.ReadLine();
            }
            PerHour = perHour;
            HoursWorkedScreen();
        }

        internal void SalaryScreen()
        {
            string x = "";
            decimal salary;
            while (!decimal.TryParse(x, out salary))
            {
                Console.Clear();
                Console.WriteLine("Podaj kwotę brutto");
                x = Console.ReadLine();
            }
            Salary = salary;
            gs.CreatePerson(1, Date, IsStudent, ContractType, PerHour, Salary, HoursWorked);
            Console.WriteLine(gs.GetPerson().Salary);
            FinalScreen(calc.init(gs.GetPerson()));
        }

        internal void HoursWorkedScreen()
        {
            string x = "";
            decimal hoursWorked;
            while (!decimal.TryParse(x, out hoursWorked))
            {
                Console.Clear();
                Console.WriteLine("Podaj ilość przepracowanych godzin (np. 160.5)");
                x = Console.ReadLine();
            }
            HoursWorked = hoursWorked;
            gs.CreatePerson(1, Date, IsStudent, ContractType, PerHour, Salary, HoursWorked);

            FinalScreen(calc.init(gs.GetPerson()));
        }

        internal void FinalScreen(List<string> l)
        {
            Console.Clear();
            foreach (var x in l)
            {
                Console.WriteLine(x);
            }
        }
    }
}
