using System;

namespace MaintenanceFeeX
{
    [Serializable]
    public class datamodel
    {
        public datamodel()
        {
            Education = 1;
            Electricity = 1;
            Fire = 1;
            Garbage = 1;
            Health = 1;
            Police = 1;
            Road = 1;
            Water = 1;
            Beauty = 1;
            Monument = 1;
            Bus = 1;
            Tram = 1;
            Metro = 1;
            Train = 1;
            Ship = 1;
            Plane = 1;
            Taxi = 1;
            Disaster = 1;
            MonoRail = 1;
            Cablecar = 1;
			Tours = 1;
        }
        public float Education { get; set; }
        public float Electricity { get; set; }
        public float Fire { get; set; }
        public float Garbage { get; set; }
        public float Health { get; set; }
        public float Police { get; set; }
        public float Road { get; set; }
        public float Disaster { get; set; }
        public float Water { get; set; }
        public float Beauty { get; set; }
        public float Monument { get; set; }
        public float Bus { get; set; }
        public float Tram { get; set; }
        public float Metro { get; set; }
        public float Ship { get; set; }
        public float Plane { get; set; }
        public float Taxi { get; set; }
        public float Train { get; set; }
        public float MonoRail { get; set; }
        public float Cablecar { get; set; }
		public float Tours { get; set; }
    }

    public static class Vars
    {
        public static datamodel Datam { get; set; }
    }
}