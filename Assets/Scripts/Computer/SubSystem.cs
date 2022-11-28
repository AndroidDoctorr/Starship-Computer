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
        public SubSystem ()
        {
            Id = Guid.NewGuid();
        }
    }
}
