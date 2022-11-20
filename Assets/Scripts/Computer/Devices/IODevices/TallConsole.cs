using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallConsole : IODevice
{
    public TallConsole()
    {
        UITypes = new ConsoleType[] {
            ConsoleType.TallConsole,
            ConsoleType.Display,
            ConsoleType.SmallConsole
        };
    }
}
