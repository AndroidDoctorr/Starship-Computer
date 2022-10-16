using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Computer.Systems.Warp_Core
{
    public class IntermixControl : SubSystem
    {
        public IntermixControl()
        {
            UsageProfile = new UsageProfile(0, Id, "Intermix Control", 0, 0, 0, 0, 0, 0);
        }
        public AntimatterInjector AntimatterInjector;
        public MatterInjector MatterInjector;

        public double IntermixRatio
        {
            get
            {
                return MatterInjector.ActualFlowRate / AntimatterInjector.ActualFlowRate;
            }
        }
        public void SetFlowLevel(float level, int priority)
        {
            MatterInjector.SetFlowLevel(level, priority);
            AntimatterInjector.SetFlowLevel(level, priority);
        }
    }
}
