using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : IODevice
{
    public Panel()
    {
        UITypes = new ConsoleType[] {
            ConsoleType.Panel,
            ConsoleType.SmallPanel
        };
    }
}
