using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tricorder : IODevice
{
    public Tricorder()
    {
        UITypes = new ConsoleType[] { ConsoleType.Tricorder };
    }
}
