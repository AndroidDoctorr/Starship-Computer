﻿using Assets.Scripts.Computer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    public class SubSystem : MonoBehaviour, ISystem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public byte Address { get; set; }
        public UsageProfile UsageProfile { get; set; }
        public PowerProfile PowerProfile { get; set; }

        public SubSystem ()
        {
            Id = Guid.NewGuid();
        }

        public event ISystem.PropertyChangeDelegate OnPropertyChange;
    }
}
