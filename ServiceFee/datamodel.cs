using System;

namespace MaintenanceFee
{
    [Serializable]
    public class datamodel
    {
        public datamodel()
        {
            education = 1;
            electricity = 1;
            fire = 1;
            garbage = 1;
            health = 1;
            police = 1;
            road = 1;
            water = 1;
            beauty = 1;
            monument = 1;
            Bus = 1;
            Tram = 1;
            Metro = 1;
            Train = 1;
            Ship = 1;
            Plane = 1;
            Taxi = 1;
            Disaster = 1;
        }
        public float education { get; set; }
        public float electricity { get; set; }
        public float fire { get; set; }
        public float garbage { get; set; }
        public float health { get; set; }
        public float police { get; set; }
        public float road { get; set; }
        public float Disaster { get; set; }
        public float water { get; set; }
        public float beauty { get; set; }
        public float monument { get; set; }
        public float Bus { get; set; }
        public float Tram { get; set; }
        public float Metro { get; set; }
        public float Ship { get; set; }
        public float Plane { get; set; }
        public float Taxi { get; set; }
        public float Train { get; set; }
    }

    public static class Vars
    {
        public static datamodel Datam { get; set; }
    }
}