using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidePanel : IODevice
{
    public WidePanel()
    {
        UITypes = new ConsoleType[] {
            ConsoleType.WidePanel,
            ConsoleType.Panel,
            ConsoleType.SmallPanel,
            ConsoleType.Display
        };
    }
}
