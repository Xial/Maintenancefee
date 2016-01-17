using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ColossalFramework;
using ICities;
using UnityEngine;

namespace MaintenanceFee
{
    public class Maintenancefee : IUserMod
    {
        public string Name => "Maintenance Fee";

        public string Description => "Changes the maintenance fees";

        public void OnSettingsUI(UIHelperBase helper)
        {
            var group = helper.AddGroup("Maintenance fees\n\r0 - 100%, 10% steps");
            group.AddSlider("Educations:", 0, 1, 0.1f, vars.datam.education, EduSlide);
            group.AddSlider("Electricity:", 0, 1, 0.1f, vars.datam.electricity, EleSlide);
            group.AddSlider("Fire Department:", 0, 1, 0.1f, vars.datam.fire, FireSlide);
            group.AddSlider("Garbage:", 0, 1, 0.1f, vars.datam.garbage, GarbSlide);
            group.AddSlider("Healthcare:", 0, 1, 0.1f, vars.datam.health, HealthSlide);
            group.AddSlider("Public Transport:", 0, 1, 0.1f, vars.datam.transport, TransportSlide);
            group.AddSlider("Police Department:", 0, 1, 0.1f, vars.datam.police, PoliceSlide);
            group.AddSlider("Roads:", 0, 1, 0.1f, vars.datam.road, RoadSlide);
            group.AddSlider("Water:", 0, 1, 0.1f, vars.datam.water, WaterSlide);
            group.AddButton("Save", Save);
        }

        private static void TransportSlide(float val)
        {
            vars.datam.transport = val;
        }

        private static void WaterSlide(float val)
        {
            vars.datam.water = val;
        }

        private static void PoliceSlide(float val)
        {
            vars.datam.police = val;
        }

        private static void HealthSlide(float val)
        {
            vars.datam.health = val;
        }

        private static void GarbSlide(float val)
        {
            vars.datam.garbage = val;
        }

        private static void FireSlide(float val)
        {
            vars.datam.fire = val;
        }

        private static void EleSlide(float val)
        {
            vars.datam.electricity = val;
        }

        private static void RoadSlide(float c)
        {
            vars.datam.road = c;
        }
        private static void EduSlide(float val)
        {
            vars.datam.education = val;
        }

        private static void Save()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(datamodel));
                using (var streamWriter = new StreamWriter("Maintenance.xml"))
                {
                    xmlSerializer.Serialize(streamWriter, vars.datam);
                }
            }
            catch (Exception e)
            {
                log.message("Unexpected " + e.GetType().Name + " saving options: " + e.Message + "\n" + e.StackTrace);
            }
        }

        public void OnEnabled()
        {
            if (File.Exists("Maintenance.xml"))
            {
                try
                {
                    var xmlSerializer = new XmlSerializer(typeof(datamodel));
                    using (var streamReader = new StreamReader("Maintenance.xml"))
                    {
                        vars.datam = (datamodel)xmlSerializer.Deserialize(streamReader);
                    }
                }
                catch (Exception e)
                {
                    log.message("Unexpected " + e.GetType().Name + " loading options: " + e.Message + "\n" + e.StackTrace);
                    vars.datam = new datamodel();
                }
            }
            else
            {
                vars.datam = new datamodel();
            }
        }

        public void OnDisabled()
        {
            vars.datam = new datamodel();
        }


        

    }
}
