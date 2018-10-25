using System;
using ICities;

namespace MaintenanceFeeX
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
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Education, 0);
                case Service.Electricity:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Electricity, 0);
                case Service.FireDepartment:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Fire, 0);
                case Service.Garbage:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Garbage, 0);
                case Service.HealthCare:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Health, 0);
                
                case Service.PublicTransport:
                    
                    
                        switch (subService)
                        {
                            case SubService.PublicTransportBus:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Bus, 0);
                            case SubService.PublicTransportTram:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Tram, 0);
                            case SubService.PublicTransportMetro:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Metro, 0);
                            case SubService.PublicTransportTrain:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Train, 0);
                            case SubService.PublicTransportShip:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Ship, 0);
                            case SubService.PublicTransportPlane:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Plane, 0);
                            case SubService.PublicTransportTaxi:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Taxi, 0);
                            case SubService.PublicTransportMonorail:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.MonoRail, 0);
                            case SubService.PublicTransportCableCar:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Cablecar, 0);
                            case SubService.PublicTransportTours:
                                return (int) Math.Round(originalMaintenanceCost * Vars.Datam.Tours, 0);    
                        default:
                            return originalMaintenanceCost;
                        }
                    
                case Service.PoliceDepartment:
                    return (int)Math.Round(originalMaintenanceCost * Vars.Datam.Police, 0);
                case Service.Road:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.Road, 0);
                case Service.Water:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.Water, 0);
                case Service.Beautification:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.Beauty, 0);
                case Service.Monument:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.Monument, 0);
                case Service.Industrial:
                    return (int) Math.Round(originalMaintenanceCost*Vars.Datam.Industrial, 0);
                default:
                    return originalMaintenanceCost;
            }
        }
    }
}