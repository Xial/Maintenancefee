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
                case Service.Disaster:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Disaster, 0);
                case Service.Education:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.education, 0);
                case Service.Electricity:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.electricity, 0);
                case Service.FireDepartment:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.fire, 0);
                case Service.Garbage:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.garbage, 0);
                case Service.HealthCare:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.health, 0);
                    
                case Service.PublicTransport:
                    switch (subService)
                    {
                        case SubService.PublicTransportBus:
                            return  (int) Math.Round(originalMaintenanceCost*Vars.Datam.Bus, 0);
                        case SubService.PublicTransportTram:
                            return (int) Math.Round(originalMaintenanceCost*Vars.Datam.Tram, 0);
                            case SubService.PublicTransportMetro:
                            return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Metro, 0);
                        case SubService.PublicTransportTrain:
                            return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Train, 0);
                        case SubService.PublicTransportShip:
                            return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Ship, 0);
                        case SubService.PublicTransportPlane:
                            return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Plane, 0);
                        case SubService.PublicTransportTaxi:
                            return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Taxi, 0);
                    }
                    return originalMaintenanceCost;
                case Service.PoliceDepartment:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.police, 0);
                case Service.Road:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.road, 0);
                case Service.Water:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.water, 0);
                case Service.Beautification:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.beauty, 0);
                case Service.Monument:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.monument, 0);
                default:
                    return originalMaintenanceCost;
            }
        }
    }
}