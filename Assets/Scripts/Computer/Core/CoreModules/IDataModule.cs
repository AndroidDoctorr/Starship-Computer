using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Core.CoreModules
{
    public enum DataSocketType { D1, N1, D2, N2, H }
    public interface IDataModule : IModule
    {
        // Physical socket compatibility
        public DataSocketType SocketType { get; }
        // Maximum storage capacity (TB/kQ)
        public decimal DataCapacity { get; }
        // Cache size (TB)
        public decimal CacheSize { get; }
    }
}
