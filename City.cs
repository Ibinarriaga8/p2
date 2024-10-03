using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class City
    {
        private PoliceStation comisaria;
        private List<Taxi> TaxiLicenses;

        //Builder
        public City()
        {
            comisaria = new PoliceStation();
            TaxiLicenses = new List<Taxi>();
        }

        public void AddTaxiLicence(string plate)
        {
            Taxi taxi = new Taxi(plate);
            TaxiLicenses.Add(taxi);
            Console.WriteLine($"Taxi with plate {plate} registered succesfully");
        }

        public void RemoveTaxiLicence(Taxi taxi)
        {
            TaxiLicenses.Remove(taxi);
            Console.WriteLine($"Taxi with plate {taxi.GetPlate()} removed succesfully");
        }

        public List<Taxi> GetTaxis()
            { return TaxiLicenses; }
        

    }


}
