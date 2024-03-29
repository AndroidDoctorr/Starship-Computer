﻿using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer.Core
{
    public class SystemBase : MonoBehaviour, ISystem
    {
        public Guid Id;
        public string Name;
        public int Priority;
        public byte Address;
        public GenericUI[] UIs;
        public UsageProfile UsageProfile;
        public PowerProfile PowerProfile;

        public virtual event ISystem.PropertyChangeDelegate OnPropertyChange;
    }
}
