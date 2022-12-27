using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class ReactorControl : SubSystem
    {
        private double _output;

        public TemperatureSensor[] TemperatureSensors;

        public override event ISystem.PropertyChangeDelegate OnPropertyChange;

        public double Output {
            get { return _output; }
            set
            {
                _output = value;
                OnPropertyChange(nameof(Output), value);
            }
        }
    }
}
