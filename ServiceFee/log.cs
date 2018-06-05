using ColossalFramework.Plugins;

namespace MaintenanceFeeX
{
    public static class log
    {
        public static void message(string msg)
        {
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, msg);
        }
    }

   
}