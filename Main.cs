namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City(); //crear ciudad
            PoliceStation station = new PoliceStation(); //crear comisaria

            //Registro de varios taxis en la ciudad
            city.AddTaxiLicence("0001 AAA");
            city.AddTaxiLicence("0002 BBB");

            //Registro de varios coches de policía
            station.AddPoliceCar("0001 CNP");
            station.AddPoliceCar("0002 CNP");


            List<PoliceCar> policeCars = station.GetPoliceCars();
            PoliceCar police1 = policeCars[0];
            PoliceCar police2 = policeCars[1];

            police1.StartPatrolling();  
            police2.AddRadar(); 
            police2.StartPatrolling();


            List<Taxi> taxis = city.GetTaxis();
            Taxi taxi1 = taxis[0];
            Taxi taxi2 = taxis[1];
            taxi2.StartRide();


            police1.UseRadar(taxi2); //intentar usar radar en un coche de policía sin radar
            police2.UseRadar(taxi2); //alerta a la comisaría y aviso a otros coches de policía

            city.RemoveTaxiLicence(taxi2 ); //quitar la licencia del vehículo infractor


        }
    }
}
    
