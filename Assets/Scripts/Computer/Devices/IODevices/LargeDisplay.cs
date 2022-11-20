using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeDisplay : IODevice
{
    public LargeDisplay()
    {
        UITypes = new ConsoleType[] { ConsoleType.LargeDisplay };
    }
}
