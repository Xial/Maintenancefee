using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace MaintenanceFeeX
{
    public class UI
    {
        private UI() { }
        public static UI Instance { get; } = new UI();

        public void SettingsUi(UIHelperBase helper)
        {
            var actualHelper = (UIHelper)helper;
            var container = (UIComponent)actualHelper.self;
            actualHelper.AddButton("Save", Save);

            var tabStrip = container.AddUIComponent<UITabstrip>();
            tabStrip.relativePosition = new Vector3(0,0);
            tabStrip.size = new Vector2(container.width -20, 40);

            var tabContainer = container.AddUIComponent<UITabContainer>();
            tabContainer.relativePosition = new Vector3(0, 40);
            tabContainer.size = new Vector2(container.width-20, container.height - tabStrip.height -20);
            tabStrip.tabPages = tabContainer;
            addTab(tabStrip, "General");
            addTab(tabStrip, "Services");
            addTab(tabStrip, "Transportation");
            addTab(tabStrip, "Industrial");

            var currentUiPanel = new List<UIPanel>();

            for (var i = 0; i < tabStrip.tabCount; i++)
            {
                currentUiPanel.Add((UIPanel)tabStrip.tabContainer.components[i]);
                currentUiPanel[i].autoLayout = true;
                currentUiPanel[i].autoLayoutDirection = LayoutDirection.Vertical;
                currentUiPanel[i].autoLayoutPadding.top = 7;
                currentUiPanel[i].autoLayoutPadding.left = 5;
                currentUiPanel[i].autoLayoutPadding.right = 5;
            }
            // Tab Section 1: General
            var panelHelper = new UIHelper(currentUiPanel[0]);
            
            Sliders.Education =
                (UISlider)
                    panelHelper.AddSlider("Education:", 0, 1, 0.05f, Vars.Datam.Education, val => Vars.Datam.Education = val);
            Sliders.Education.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Education*100}%";

            Sliders.Electricity =
                (UISlider)
                    panelHelper.AddSlider("Electricity:", 0, 1, 0.05f, Vars.Datam.Electricity, val => Vars.Datam.Electricity = val);
            Sliders.Electricity.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Electricity*100}%";

            Sliders.Garbage =
                (UISlider)
                    panelHelper.AddSlider("Garbage:", 0, 1, 0.05f, Vars.Datam.Garbage, val => Vars.Datam.Garbage = val);
            Sliders.Garbage.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Garbage * 100}%";

            Sliders.Monuments =
                (UISlider)
                    panelHelper.AddSlider("Monuments:", 0, 1, 0.05f, Vars.Datam.Monument, val => Vars.Datam.Monument = val);
            Sliders.Monuments.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Monument * 100}%";

            Sliders.Beauty =
                (UISlider)
                    panelHelper.AddSlider("Parks:", 0, 1, 0.05f, Vars.Datam.Beauty, val => Vars.Datam.Beauty = val);
            Sliders.Beauty.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Beauty * 100}%";

            Sliders.Roads =
                (UISlider)
                    panelHelper.AddSlider("Roads:", 0, 1, 0.05f, Vars.Datam.Road, val => Vars.Datam.Road = val);
            Sliders.Roads.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Road * 100}%";
            Sliders.Water =
                (UISlider)
                    panelHelper.AddSlider("Water Service:", 0, 1, 0.05f, Vars.Datam.Water, val => Vars.Datam.Water = val);
            Sliders.Water.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Water * 100}%";

            // Tab Section 2: Services
            panelHelper = new UIHelper(currentUiPanel[1]);

            Sliders.Disaster =
               (UISlider)
                   panelHelper.AddSlider("Disaster:", 0, 1, 0.05f, Vars.Datam.Disaster, val => Vars.Datam.Disaster = val);
            Sliders.Disaster.eventTooltipHover +=
                (component, param) => component.tooltip = $"{Vars.Datam.Disaster * 100}%";
            Sliders.Fire =
                (UISlider)
                    panelHelper.AddSlider("Fire Department:", 0, 1, 0.05f, Vars.Datam.Fire, val => Vars.Datam.Fire = val);
            Sliders.Fire.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Fire * 100}%";
            Sliders.Healthcare =
                (UISlider)
                    panelHelper.AddSlider("Healthcare:", 0, 1, 0.05f, Vars.Datam.Health, val => Vars.Datam.Health = val);
            Sliders.Healthcare.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Health * 100}%";
            Sliders.Police =
                (UISlider)
                    panelHelper.AddSlider("Police Department:", 0, 1, 0.05f, Vars.Datam.Police, val => Vars.Datam.Police = val);
            Sliders.Police.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Police * 100}%";

            // Tab Section 3: Transportation
            panelHelper = new UIHelper(currentUiPanel[2]);

            Sliders.Bus =
                (UISlider) panelHelper.AddSlider("Bus:", 0, 1, 0.05f, Vars.Datam.Bus, val => Vars.Datam.Bus = val);
            Sliders.Bus.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Bus * 100}%";

            Sliders.Tram =
                (UISlider)panelHelper.AddSlider("Tram:", 0, 1, 0.05f, Vars.Datam.Tram, val => Vars.Datam.Tram = val);
            Sliders.Tram.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Tram * 100}%";

            Sliders.Metro =
                (UISlider)panelHelper.AddSlider("Metro:", 0, 1, 0.05f, Vars.Datam.Metro, val => Vars.Datam.Metro = val);
            Sliders.Metro.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Metro * 100}%";

            Sliders.Train =
                (UISlider)panelHelper.AddSlider("Train:", 0, 1, 0.05f, Vars.Datam.Train, val => Vars.Datam.Train = val);
            Sliders.Train.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Train * 100}%";

            Sliders.Ship =
                (UISlider)panelHelper.AddSlider("Ship:", 0, 1, 0.05f, Vars.Datam.Ship, val => Vars.Datam.Ship = val);
            Sliders.Ship.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Ship*100}%";

            Sliders.Plane =
                (UISlider)panelHelper.AddSlider("Plane:", 0, 1, 0.05f, Vars.Datam.Plane, val => Vars.Datam.Plane = val);
            Sliders.Plane.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Plane * 100}%";

            Sliders.Taxi =
				(UISlider)panelHelper.AddSlider("Taxi:", 0, 1, 0.05f, Vars.Datam.Taxi, val => Vars.Datam.Taxi = val);
            Sliders.Taxi.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Taxi * 100}%";

            Sliders.MonoRail =
				(UISlider)panelHelper.AddSlider("Monorail:", 0, 1, 0.05f, Vars.Datam.MonoRail, val => Vars.Datam.MonoRail = val);
            Sliders.MonoRail.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.MonoRail * 100}%";

            Sliders.Cablecar =
				(UISlider)panelHelper.AddSlider("Cablecar:", 0, 1, 0.05f, Vars.Datam.Cablecar, val => Vars.Datam.Cablecar = val);
            Sliders.Cablecar.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Cablecar * 100}%";

			Sliders.Tours =
				(UISlider)panelHelper.AddSlider("Sightseeing:", 0, 1, 0.05f, Vars.Datam.Tours, val => Vars.Datam.Tours = val);
            Sliders.Tours.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Tours * 100}%";

            // Tab Section 4: Industrial
            panelHelper = new UIHelper(currentUiPanel[3]);

            Sliders.IndustrialGeneric =
				(UISlider)panelHelper.AddSlider("Generic Industry:", 0, 1, 0.05f, Vars.Datam.IndustrialGeneric, val => Vars.Datam.IndustrialGeneric = val);
            Sliders.IndustrialGeneric.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.IndustrialGeneric * 100}%"; 

            Sliders.IndustrialForestry =
                (UISlider)panelHelper.AddSlider("Forestry:", 0, 1, 0.05f, Vars.Datam.IndustrialForestry, val => Vars.Datam.IndustrialForestry = val);
            Sliders.IndustrialForestry.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.IndustrialForestry * 100}%";

            Sliders.IndustrialFarming =
                (UISlider)panelHelper.AddSlider("Farming:", 0, 1, 0.05f, Vars.Datam.IndustrialFarming, val => Vars.Datam.IndustrialFarming = val);
            Sliders.IndustrialFarming.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.IndustrialFarming * 100}%";

            Sliders.IndustrialOre =
                (UISlider)panelHelper.AddSlider("Ore:", 0, 1, 0.05f, Vars.Datam.IndustrialOre, val => Vars.Datam.IndustrialOre = val);
            Sliders.IndustrialOre.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.IndustrialOre * 100}%";

            Sliders.IndustrialOil =
                (UISlider)panelHelper.AddSlider("Oil:", 0, 1, 0.05f, Vars.Datam.IndustrialOil, val => Vars.Datam.IndustrialOil = val);
            Sliders.IndustrialOil.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.IndustrialOil * 100}%";

            tabContainer.selectedIndex = 2;
            tabContainer.selectedIndex = 1;
            tabContainer.selectedIndex = 0;
        }

        private static void Save()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(datamodel));
                using (var streamWriter = new StreamWriter("MaintenanceX.xml"))
                {
                    xmlSerializer.Serialize(streamWriter, Vars.Datam);
                }
            }
            catch (Exception e)
            {
                log.message("Unexpected " + e.GetType().Name + " saving options: " + e.Message + "\n" + e.StackTrace);
            }
        }

        private static void addTab(UITabstrip strip, string name)
        {
            var tabButton = strip.AddTab(name);
            tabButton.normalBgSprite = "SubBarButtonBase";
            tabButton.disabledBgSprite = "SubBarButtonBaseDisabled";
            tabButton.focusedBgSprite = "SubBarButtonBaseFocused";
            tabButton.hoveredBgSprite = "SubBarButtonBaseHovered";
            tabButton.pressedBgSprite = "SubBarButtonBasePressed";

            tabButton.textPadding = new RectOffset(5, 10, 5, 10);
            tabButton.autoSize = true;
            tabButton.tooltip = name;
        }
    }


}
