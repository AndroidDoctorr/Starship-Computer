using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class MainReactorControl : SubSystem
    {
        public GenericUI ConsoleUI;

        public TemperatureSensor[] TemperatureSensors;

        private double _output;
        public double Output {
            get { return _output; }
            set
            {
                _output = value;
                // OnPropertyChange("Output", value);
            }
        }
    }
}
