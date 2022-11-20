using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : IODevice
{
    public Console()
    {
        UITypes = new ConsoleType[] { ConsoleType.StandardConsole };
    }
}
