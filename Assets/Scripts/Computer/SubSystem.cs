using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public abstract class SubSystem : SystemBase
    {
        public GenericUI[] UIs;
        public IODevice[] IODevices;
        public SubSystem ()
        {
            Id = Guid.NewGuid();
        }
        public Device[] GetDevices()
        {
            return GetIODevices().Concat(GetSystemDevices()).ToArray();
        }
        public Device[] GetIODevices()
        {
            return IODevices;
        }
        public virtual Device[] GetSystemDevices()
        {
            return new Device[] { };
        }
    }
}
