﻿namespace Practice1
{
    class SpeedRadar : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();

        }

        public void TriggerRadar(RegisteredVehicle vehicle)
        {
            plate = vehicle.GetPlate();
            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
        }
        
        public bool DrivingLegally()
        {
            bool legal = true;
            if (speed > legalSpeed)
            {   
                legal = false;
            }

            return legal;
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}