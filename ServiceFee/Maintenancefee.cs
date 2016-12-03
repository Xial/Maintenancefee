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
        readonly SettingsUiDelegate _uiDelegate = UI.Instance.SettingsUi;

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
