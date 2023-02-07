using Assets.Scripts.Computer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Core
{
    public abstract class SubSystem : SystemBase
    {
        public List<IODevice> IODevices;
        public SubSystem ()
        {
            Id = Guid.NewGuid();
        }
        public IEnumerable<Device> GetDevices()
        {
            return GetIODevices().Concat(GetSystemDevices());
        }
        public IEnumerable<Device> GetIODevices()
        {
            return IODevices;
        }
        public virtual IEnumerable<Device> GetSystemDevices()
        {
            return new List<Device>();
        }
    }
}
