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
        }

        public void NotifyPolice(Vehicle car)
        {
            //Notify each police car in police station
            foreach (PoliceCar policeCar in policeCars) 
            { 
               policeCar.ChaseCar(car);
            }
        }
        public void AddPoliceCar(string plate)
        {
            PoliceCar policeCar = new PoliceCar(plate); //registrar coches mediante su matrícula
            policeCars.Add(policeCar);
        }

    }
}
