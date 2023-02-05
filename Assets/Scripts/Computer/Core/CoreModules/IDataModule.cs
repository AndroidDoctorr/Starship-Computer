using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public interface IDataModule : IModule
    {
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; }
        // Cache size (TB)
        public decimal CacheSize { get; }
    }
}
