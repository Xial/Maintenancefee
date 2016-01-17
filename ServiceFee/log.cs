using ColossalFramework.Plugins;

namespace MaintenanceFee
{
    public static class log
    {
        public static void message(string msg)
        {
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, msg);
        }
    }

   
}