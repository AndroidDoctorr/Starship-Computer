using Assets.Scripts;
using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideTablet : IODevice
{
    public WideTablet()
    {
        UITypes = new ConsoleType[] {
            ConsoleType.WideTablet,
            ConsoleType.Tablet,
            ConsoleType.Pad,
            ConsoleType.Tricorder
        };
    }
}
