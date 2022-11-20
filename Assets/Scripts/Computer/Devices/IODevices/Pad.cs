using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : IODevice
{
    public Pad()
    {
        UITypes = new ConsoleType[] { ConsoleType.Pad };
    }
}
