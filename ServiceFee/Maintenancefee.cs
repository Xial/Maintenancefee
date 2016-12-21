using System;
using System.IO;
using System.Xml.Serialization;
using ICities;

namespace MaintenanceFee
{
    public class Maintenancefee : IUserMod
    {
        public string Name => "Maintenance Fee";

        public string Description => "Changes the maintenance fees";
        public delegate void SettingsUiDelegate(UIHelperBase helper);

        private readonly SettingsUiDelegate _uiDelegate = UI.Instance.SettingsUi;

        public void OnSettingsUI(UIHelperBase helper)
        {
            _uiDelegate(helper);
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
                        log.message("exists"); 
                        Vars.Datam = (datamodel)xmlSerializer.Deserialize(streamReader);
                    }
                }
                catch (Exception e)
                {
                    log.message("Unexpected " + e.GetType().Name + " loading options: " + e.Message + "\n" + e.StackTrace);
                    Vars.Datam = new datamodel();
                }
            }
            else
            {
                Vars.Datam = new datamodel();
            }
        }

        public void OnDisabled()
        {
            Vars.Datam = new datamodel();
        }
    }
}
