using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public class AtmosphereGroup : SubSystem
    {
        public ACUnit[] ACUnits;
        public TemperatureSensor[] TemperatureSensors;
        public HumiditySensor[] HumiditySensors;

        private void Start()
        {
            
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
