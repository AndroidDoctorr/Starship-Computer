using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer
{
    public class ShipSystem
    {
        protected bool _isActive;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public byte[] Address { get; set; }
        public UsageProfile UsageProfile { get; set; }
        public Dictionary<string, GenericUI> UIs { get; set; } = new Dictionary<string, GenericUI>();
        public Dictionary<byte, SubSystem> SubSystems { get; set; } = new Dictionary<byte, SubSystem>();

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
