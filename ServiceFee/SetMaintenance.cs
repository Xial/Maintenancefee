using System;
using ICities;

namespace MaintenanceFee
{
    public class SetMaintenance : EconomyExtensionBase
    { 
        public override int OnGetMaintenanceCost(int originalMaintenanceCost, Service service, SubService subService, Level level)
        {
            switch (service)
            {
                case Service.Education:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.education, 0);
                case Service.Electricity:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.electricity, 0);
                case Service.FireDepartment:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.fire, 0);
                case Service.Garbage:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.garbage, 0);
                case Service.HealthCare:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.health, 0);
                case Service.PublicTransport:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.transport, 0);
                case Service.PoliceDepartment:
                    return (int)Math.Round(originalMaintenanceCost * vars.datam.police, 0);
                case Service.Road:
                    return (int) Math.Round(originalMaintenanceCost*vars.datam.road, 0);
                case Service.Water:
                    return (int) Math.Round(originalMaintenanceCost*vars.datam.water, 0);
                case Service.Beautification:
                    return (int) Math.Round(originalMaintenanceCost*vars.datam.beauty, 0);
                case Service.Monument:
                    return (int) Math.Round(originalMaintenanceCost*vars.datam.monument, 0);
                default:
                    return originalMaintenanceCost;
            }
        }
    }
}