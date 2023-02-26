using Assets.Scripts;
using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Core;
using Assets.Scripts.Computer.Systems.Environment;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
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
    public override SystemBase System { get { return Environment; } } 

    void Start()
    {
        // Device[] devices = Environment.GetDevices();
        AtmosphereList.PopulateSystemList(Environment.AtmosphereGroups);
        LightGroupList.PopulateSystemList(Environment.LightingGroups);
    }
}
