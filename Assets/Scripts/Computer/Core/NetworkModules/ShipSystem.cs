using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Core
{
    public class ShipSystem : SystemBase
    {
        protected bool _isActive;
        public Dictionary<byte, SubSystem> SubSystems = new Dictionary<byte, SubSystem>();

        public ShipSystem()
        {
            Id = Guid.NewGuid();
        }

        public virtual void ShutDown()
        {
            _isActive = false;
        }
        public virtual void StartUp()
        {
            _isActive = true;
        }
        public bool IsActive()
        {
            return _isActive;
        }
        public SystemResponse IssueSystemCommand()
        {
            return new SystemResponse()
            {
                Code = 400,
                Source = Name,
                Message = "Unrecognized Command"
            };
        }
        public object GetDeviceProperty(byte[] address, string name)
        {
            return null;
        }
    }
}
