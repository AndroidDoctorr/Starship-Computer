using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public class AtmosphereGroup : SubSystem
    {
        // public Atmosphere Atmosphere;
        public ACUnit[] ACUnits;
        public TemperatureSensor[] TemperatureSensors;
        public HumiditySensor[] HumiditySensors;
        // Get the actual values (measured by sensors)
        public double Humidity => GetHumidity();
        public double Temperature => GetTemperature();
        public override event ISystem.PropertyChangeDelegate OnPropertyChange;

        private void OnEnable()
        {
            foreach (TemperatureSensor tempSensor in TemperatureSensors)
                tempSensor.OnTemperatureChange += UpdateTemperature;
            foreach (HumiditySensor humidSensor in HumiditySensors)
                humidSensor.OnHumidityChange += UpdateHumidity;
        }
        private void OnDestroy()
        {
            foreach (TemperatureSensor tempSensor in TemperatureSensors)
                tempSensor.OnTemperatureChange -= UpdateTemperature;
            foreach (HumiditySensor humidSensor in HumiditySensors)
                humidSensor.OnHumidityChange -= UpdateHumidity;
        }
        private void UpdateTemperature(double temp)
        {
            OnPropertyChange(nameof(Temperature), Math.Round(temp, 1), EnvironmentPropGroup.Atmosphere);
        }
        private void UpdateHumidity(double humid)
        {
            OnPropertyChange(nameof(Humidity), Math.Round(humid, 1), EnvironmentPropGroup.Atmosphere);
        }
        public void SetTemperature(double temp)
        {
            // TODO: Update to return false or throw error if out of range
            foreach (ACUnit unit in ACUnits)
                unit.SetTemperature(temp);
        }
        public void SetHumidity(double humid)
        {
            // TODO: Update to return false or throw error if out of range
            foreach (ACUnit unit in ACUnits)
                unit.SetHumidity(humid);
        }
        public double GetTemperature()
        {
            return TemperatureSensors.Select(s => s.GetTemperature()).Sum() /
                TemperatureSensors.Length;
        }
        public double GetHumidity()
        {
            return HumiditySensors.Select(s => s.GetHumidity()).Sum() /
                HumiditySensors.Length;
        }
    }
}
