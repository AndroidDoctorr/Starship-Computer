using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallConsole : IODevice
{
    public SmallConsole()
    {
        UITypes = new ConsoleType[] { ConsoleType.SmallConsole };
    }
}
