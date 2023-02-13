using Assets.Scripts.Computer.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Computer.Auth
{
    public class Identity
    {
        public Guid PersonalId { get; }
        public DateTime BirthDate { get; }
        public DateTime EnlistDate { get; }
        public string GeneticProfile { get; }
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public string NickName { get; private set; }
        public Vector3 Location { get; }
    }
}
