using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : IODevice
{
    public Tablet()
    {
        UITypes = new ConsoleType[] { ConsoleType.Tablet };
    }
}
