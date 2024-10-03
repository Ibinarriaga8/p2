using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class PoliceStation
    {
        //atributos:
        private bool alert;
        private List<PoliceCar> policeCars; //lista de coches de policía
        public PoliceStation()
        {
            alert = false;
            policeCars = new List<PoliceCar>();
        }



        public void AlertCar(string plate)
        {
            alert = true;
            //Notify each police car in police station
            Console.WriteLine($"Alarm activated: all police cars proceed to pursuit vehicle with plate {plate}"); 
            foreach (PoliceCar policeCar in policeCars) 
            { 
               policeCar.ChaseCar(plate);
            }
        }
        public void AddPoliceCar(string plate)
        {
            PoliceCar policeCar = new PoliceCar(plate); //registrar coches mediante su matrícula
            Console.WriteLine($"Police car with plate {plate} registered succesfully");
            policeCar.SetStation(this);
            policeCars.Add(policeCar);
        }

        public List<PoliceCar> GetPoliceCars()
        { return policeCars;}


    }
}
