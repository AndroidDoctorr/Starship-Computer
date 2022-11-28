using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACUnit : Device
{
    public static float MaximumTemperature = 310;
    public static float MinimumTemperature = 280;
    public float Temperature = 295;
    public float Humidity = 0.1f;

    public float HumiditySetting = 0.1f;
    public float TempSetting = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
