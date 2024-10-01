namespace Practice1
{
    public class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool onPursuit;
        private PoliceStation? policeStation;


        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            onPursuit = false;
        }

        public void UseRadar(Vehicle vehicle)
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
                    if (policeStation is not null) 
                    {
                        string plate = vehicle.GetPlate();  
                        policeStation.AlertCar(plate); //alerts police station
                    }
                    ChaseCar(vehicle); //atempts chasing car if it's currently not on pursuit

                }
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
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

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }

        public void ChaseCar(Vehicle vehicle)
        {
            if (onPursuit)
            {
                Console.WriteLine(WriteMessage("Already on persuit"));
            }
            else
            {
                onPursuit = true;
                Console.WriteLine(WriteMessage($"chasing {vehicle}"));
            }

        }
    }
}