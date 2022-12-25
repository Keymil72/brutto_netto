using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brutto_netto
{
    internal class Calculate
    {
        Tax tax = new Tax();
        List<string> calculations = new List<string>();
        public decimal amount = 0;

        internal List<string> init(Person p)
        {
            if (p.ContractType == 1)
            {
                amount = p.Salary;
            }
            else
            {
                amount = p.PerHour * p.HoursWorked;
            }

            if (p.IsStudent && p.Age <= 26)
            {
                calculations.Add("Podana osoba jest studentem i jest w wieku do 26 lat");
                calculations.Add("Kwota netto = brutto!");
                calculations.Add("Kwota netto: " + amount);
            }
            else
            {
                calculations.Add("*** Kwota brutto: " + amount + " ***");
                calculations.Add("");
                PensionTax(p);
                RentalTax(p);
                SicknessTax(p);
                SocialTax(p);
                HealthTax(p);
                DeducitibleTax(p);
                IncomeTax(p);
                
                calculations.Add("");
                calculations.Add("*** Kwota netto: " + amount + " ***");

            }

            return calculations;
        }
        internal void PensionTax(Person p)
        {
            calculations.Add("Wartość składki emerytalnej: " + amount * (tax.PensionTax / 100));
        }

        internal void RentalTax(Person p)
        {
            calculations.Add("Wartość skłądki rentownej: " + amount * (tax.RentalTax/ 100));
        }

        internal void SicknessTax(Person p)
        {
            calculations.Add("Wartość skłądki chorobowej: " + amount * (tax.SicknessTax / 100));
        }

        internal void SocialTax(Person p)
        {
            decimal value = amount * (tax.SocialTax / 100);
            amount -= value;
            calculations.Add("Łączna wartość skłądek społęcznych: " + value + " (" + tax.SocialTax + "%)");
        }

        internal void HealthTax(Person p)
        {
            calculations.Add("Wysokość skłądki zdrowotnej: " + amount * (tax.HealthTax / 100));
        }

        internal void DeducitibleTax(Person p)
        {
            amount -= 250;
            calculations.Add("Koszt uzyskania przychodu z jednego źróła: " + tax.DeducitibleTax);
        }

        internal void IncomeTax(Person p)
        {
            decimal value = amount * 12;
            decimal cost = 0;
            string message;
            switch (value)
            {
                case var expression when value <= tax.Min:
                    cost = (amount * (tax.MinPercent/100) - 300);
                    break;
                case var expression when value < tax.Min && value <= tax.Max:
                    cost = (amount * (tax.MidPercent / 100) - 300);
                    break;
                default:
                    cost = (amount * (tax.MaxPercent / 100) - 300);
                    break;
                    
            }
            message = (cost >= 0) ? "Podatek dochodowy wynosi: " + cost : "Podatek dochodowy wynosi: " + 0;
            calculations.Add(message);
        }

    }
}
