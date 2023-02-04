using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core
{
    public interface ISystem
    {
        public delegate void PropertyChangeDelegate(string propertyName, object newValue);
        event PropertyChangeDelegate OnPropertyChange;
    }
}
