using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACUnit : Device
{
    public static float MaximumTemperature = 310;
    public static float MinimumTemperature = 280;

    public float HeatRate = 1;
    public float HumidifyRate = 0.01f;
    public float RoomSize = 1000;
    public float Temperature = 295;
    public float Humidity = 0.1f;

    public float HumiditySetting  = 0.1f;
    public float TempSetting = 0.5f;
    public bool StartAtSettings = true;
    void Start()
    {
        if (StartAtSettings)
        {
            Temperature = GetTempFromSetting();
            Humidity = HumiditySetting;
        }
    }

    void Update()
    {
        // TODO: Schedule on/off periods with a minimum delay between
        float targetTemp = GetTempFromSetting();
        if (targetTemp != Temperature)
            HeatOrCoolToSetting();

        if (Humidity != HumiditySetting)
            HumidifyToSetting();
    }
    private void HeatOrCoolToSetting()
    {
        float targetTemp = GetTempFromSetting();
        float tempChange = HeatRate / RoomSize;
        float diff = targetTemp - Temperature;
        if (diff == 0) return;
        if (Mathf.Abs(diff) < tempChange)
            Temperature = targetTemp;
        else if (diff > 0)
            Temperature += tempChange;
        else Temperature -= tempChange;
    }
    private void HumidifyToSetting()
    {
        float humidChange = HumidifyRate / RoomSize;
        float diff = HumiditySetting - Humidity;
        if (diff == 0) return;
        if (Mathf.Abs(diff) < humidChange)
            Humidity = HumiditySetting;
        else if (diff > 0)
            Humidity += humidChange;
        else Humidity -= humidChange;
    }
    private float GetTempFromSetting()
    {
        float tempRange = MaximumTemperature - MinimumTemperature;
        return TempSetting * tempRange + MinimumTemperature;
    }
}
