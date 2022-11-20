using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPanel : IODevice
{
    public SmallPanel()
    {
        UITypes = new ConsoleType[] { ConsoleType.SmallPanel };
    }
}
