using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Environment.SubSystems
{
    public class Lighting : SubSystem
    {
        public LightFixture[] LightFixtures;

        public bool DisconnectLightFixture()
        {
            // Generic method for subsystems - ConnectDevice?
            // Or this makes use of it/extends it?
            return true;
        }
        public bool ConnectLightFixture()
        {
            return true;
        }
    }
}
