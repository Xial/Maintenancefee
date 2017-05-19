using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace MaintenanceFee
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
            addTab(tabStrip, "Emergency Services");
            addTab(tabStrip, "Public transport");

            var currentUiPanel = new List<UIPanel>();
            
            for (var i = 0; i < tabStrip.tabCount; i++)
            {
                currentUiPanel.Add((UIPanel)tabStrip.tabContainer.components[i]);
                currentUiPanel[i].autoLayout = true;
                currentUiPanel[i].autoLayoutDirection = LayoutDirection.Vertical;
                currentUiPanel[i].autoLayoutPadding.top = 5;
                currentUiPanel[i].autoLayoutPadding.left = 10;
                currentUiPanel[i].autoLayoutPadding.right = 10;
            }
            var panelHelper = new UIHelper(currentUiPanel[0]);

           
            Sliders.Education =
                (UISlider)
                    panelHelper.AddSlider("Educations:", 0, 1, 0.1f, Vars.Datam.education, val => Vars.Datam.education = val);
            Sliders.Education.eventTooltipHover +=
                (component, param) => component.tooltip = $"{Vars.Datam.education*100}%";
            Sliders.Electricity =
                (UISlider)
                    panelHelper.AddSlider("Electricity:", 0, 1, 0.1f, Vars.Datam.electricity,
                        val => Vars.Datam.electricity = val);
            Sliders.Electricity.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.electricity*100}%";
            
            Sliders.Garbage =
                (UISlider)
                    panelHelper.AddSlider("Garbage:", 0, 1, 0.1f, Vars.Datam.garbage, val => Vars.Datam.garbage = val);
            Sliders.Garbage.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.garbage * 100}%";
            
            Sliders.Monuments =
                (UISlider)
                    panelHelper.AddSlider("Monuments:", 0, 1, 0.1f, Vars.Datam.monument, val => Vars.Datam.monument = val);
            Sliders.Monuments.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.monument * 100}%";
            Sliders.Beauty =
                (UISlider)
                    panelHelper.AddSlider("Parks:", 0, 1, 0.1f, Vars.Datam.beauty, val => Vars.Datam.beauty = val);
            Sliders.Beauty.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.beauty * 100}%";
            
            Sliders.Roads =
                (UISlider)
                    panelHelper.AddSlider("Roads:", 0, 1, 0.1f, Vars.Datam.road, val => Vars.Datam.road = val);
            Sliders.Roads.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.road * 100}%";
            Sliders.Water =
                (UISlider)
                    panelHelper.AddSlider("Water Service:", 0, 1, 0.1f, Vars.Datam.water, val => Vars.Datam.water = val);
            Sliders.Water.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.water * 100}%";

            panelHelper = new UIHelper(currentUiPanel[1]);
            Sliders.Disaster =
               (UISlider)
                   panelHelper.AddSlider("Disaster:", 0, 1, 0.1f, Vars.Datam.Disaster, val => Vars.Datam.Disaster = val);
            Sliders.Disaster.eventTooltipHover +=
                (component, param) => component.tooltip = $"{Vars.Datam.Disaster * 100}%";
            Sliders.Fire =
                (UISlider)
                    panelHelper.AddSlider("Fire Department:", 0, 1, 0.1f, Vars.Datam.fire, val => Vars.Datam.fire = val);
            Sliders.Fire.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.fire * 100}%";
            Sliders.Healthcare =
                (UISlider)
                    panelHelper.AddSlider("Healthcare:", 0, 1, 0.1f, Vars.Datam.health, val => Vars.Datam.health = val);
            Sliders.Healthcare.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.health * 100}%";
            Sliders.Police =
                (UISlider)
                    panelHelper.AddSlider("Police Department:", 0, 1, 0.1f, Vars.Datam.police, val => Vars.Datam.police = val);
            Sliders.Police.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.police * 100}%";


            panelHelper = new UIHelper(currentUiPanel[2]);
            Sliders.Bus =
                (UISlider) panelHelper.AddSlider("Bus:", 0, 1, 0.1f, Vars.Datam.Bus, val => Vars.Datam.Bus = val);
            Sliders.Bus.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Bus * 100}%";

            Sliders.Tram =
                (UISlider)panelHelper.AddSlider("Tram:", 0, 1, 0.1f, Vars.Datam.Tram, val => Vars.Datam.Tram = val);
            Sliders.Tram.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Tram * 100}%";

            Sliders.Metro =
                (UISlider)panelHelper.AddSlider("Metro:", 0, 1, 0.1f, Vars.Datam.Metro, val => Vars.Datam.Metro = val);
            Sliders.Metro.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Metro * 100}%";

            Sliders.Train =
                (UISlider)panelHelper.AddSlider("Train:", 0, 1, 0.1f, Vars.Datam.Train, val => Vars.Datam.Train = val);
            Sliders.Train.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Train * 100}%";

            Sliders.Ship =
                (UISlider)panelHelper.AddSlider("Ship:", 0, 1, 0.1f, Vars.Datam.Ship, val => Vars.Datam.Ship = val);
            Sliders.Ship.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Ship*100}%";

            Sliders.Plane =
                (UISlider)panelHelper.AddSlider("Plane:", 0, 1, 0.1f, Vars.Datam.Plane, val => Vars.Datam.Plane = val);
            Sliders.Plane.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Plane * 100}%";

            Sliders.Taxi = (UISlider)panelHelper.AddSlider("Taxi:", 0, 1, 0.1f, Vars.Datam.Taxi, val => Vars.Datam.Taxi = val);
            Sliders.Taxi.eventTooltipHover += (component, param) => component.tooltip = $"{Vars.Datam.Taxi * 100}%";

            tabContainer.selectedIndex = 1;
            tabContainer.selectedIndex = 0;
        }
        
        private static void Save()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(datamodel));
                using (var streamWriter = new StreamWriter("Maintenance.xml"))
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

            tabButton.textPadding = new RectOffset(10, 10, 10, 10);
            tabButton.autoSize = true;
            tabButton.tooltip = name;
        }
    }

    
}