namespace Practice1
{
    public class PoliceCar : RegisteredVehicle
       {
       //constant string as TypeOfVehicle wont change along PoliceCar instances
       private const string typeOfVehicle = "Police Car";
       private bool isPatrolling;
       private SpeedRadar? speedRadar; //los coches de policía pueden tener o no un radar
       private bool onPursuit;
       private PoliceStation? policeStation;


       public PoliceCar(string plate) : base(typeOfVehicle, plate)
       {
           isPatrolling = false;
           onPursuit = false;
       }

       //Radar
       public void AddRadar()
       {
           speedRadar = new SpeedRadar(); //create a radar for the PoliceCar
       }

       public void UseRadar(RegisteredVehicle vehicle)
       {
           if (speedRadar != null)
           {
               if (isPatrolling)
               {
                   speedRadar.TriggerRadar(vehicle);
                   bool driving_legally = speedRadar.DrivingLegally();

                   string meassurement = "";
                   if (driving_legally)
                   {
                       meassurement = speedRadar.WriteMessage("Driving legally.");
                   }
                   else
                   {
                       //Vehicle catched above legal speed
                       meassurement = speedRadar.WriteMessage("Catched above legal speed");
                       string plate = vehicle.GetPlate();

                       ChaseCar(plate); //atempts chasing car if it's currently not on pursuit

                       if (policeStation is not null)
                       {
                           policeStation.AlertCar(plate); //alerts police station
                       }

                   }
                   Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
               }
               else
               {
                   Console.WriteLine(WriteMessage($"has no active radar."));
               }

           }
       }
       public void PrintRadarHistory()
       {
           if (speedRadar != null)
           {
               Console.WriteLine(WriteMessage("Report radar speed history:"));
               foreach (float speed in speedRadar.SpeedHistory)
               {
                   Console.WriteLine(speed);
               }
           }
       }

       public bool IsPatrolling()
       {
           return isPatrolling;
       }

       public void StartPatrolling()
       {
           if (!isPatrolling)
           {
               isPatrolling = true;
               Console.WriteLine(WriteMessage("started patrolling."));
           }
           else
           {
               Console.WriteLine(WriteMessage("is already patrolling."));
           }
       }

       public void EndPatrolling()
       {
           if (isPatrolling)
           {
               isPatrolling = false;
               Console.WriteLine(WriteMessage("stopped patrolling."));
           }
           else
           {
               Console.WriteLine(WriteMessage("was not patrolling."));
           }
       }

       public void SetStation(PoliceStation station)
       {
           policeStation = station;
       }


       public void ChaseCar(string plate)

       {
           if (isPatrolling)
           {
               if (onPursuit)
               {
                   Console.WriteLine(WriteMessage("Already on pursuit"));
               }
               else
               {
                   onPursuit = true;
                   Console.WriteLine(WriteMessage($"chasing car with plate {plate}"));
               }
           }
           else
           {
               Console.WriteLine(WriteMessage("is not patrolling"));
           }
       }
    }   
}