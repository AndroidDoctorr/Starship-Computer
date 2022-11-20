using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : IODevice
{
    public Display()
    {
        UITypes = new ConsoleType[] { ConsoleType.Display };
    }
}
