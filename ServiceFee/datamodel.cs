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
            transport = 1;
            water = 1;
        }
        public float education { get; set; }
        public float electricity { get; set; }
        public float fire { get; set; }
        public float garbage { get; set; }
        public float health { get; set; }
        public float police { get; set; }
        public float road { get; set; }
        public float transport { get; set; }
        public float water { get; set; }
    }

    public static class vars
    {
        public static datamodel datam { get; set; }
    }
}