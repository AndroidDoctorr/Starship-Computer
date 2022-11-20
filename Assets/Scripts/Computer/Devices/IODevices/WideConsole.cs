using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideConsole : IODevice
{
    public WideConsole()
    {
        UITypes = new ConsoleType[] { ConsoleType.WideConsole, ConsoleType.StandardConsole };
    }
}
