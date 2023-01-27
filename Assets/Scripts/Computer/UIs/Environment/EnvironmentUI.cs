using Assets.Scripts;
using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Systems.Environment;
using Assets.Scripts.Computer.UI_Elements.ListItems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentUI : GenericUI
{
    public Environment Environment;
    public UIScrollView AtmosphereList;
    public UIScrollView LightGroupList;
    void Start()
    {
        // Device[] devices = Environment.GetDevices();

        AtmosphereList.PopulateList(Environment.AtmosphereGroups.Select(ag =>
            new AtmosphereData(ag)
        ).ToArray());

        LightGroupList.PopulateList(Environment.LightingGroups.Select(lg =>
            new LightingGroupData(lg)
        ).ToArray());
    }
}
