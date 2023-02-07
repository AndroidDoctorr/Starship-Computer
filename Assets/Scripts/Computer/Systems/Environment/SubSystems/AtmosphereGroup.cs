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
        public double Humidity => (GetHumidity() * 100);
        public double Temperature => GetTemperature();
        public int Count => ACUnits.Length;
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
            OnPropertyChange(nameof(Temperature), Temperature);
        }
        private void UpdateHumidity(double humid)
        {
            OnPropertyChange(nameof(Humidity), Humidity);
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
            return TemperatureSensors.Average(s => s.GetTemperature());
        }
        public double GetHumidity()
        {
            return HumiditySensors.Average(s => s.GetHumidity());
        }
    }
}
