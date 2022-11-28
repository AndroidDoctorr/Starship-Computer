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

    public float HumiditySetting { get; private set; } = 0.1f;
    public float TempSetting { get; private set; } = 0.5f;
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

    public void SetHumidity(float humidity)
    {
        // TODO: Return error message or something if out of range
        if (humidity > 1)
            HumiditySetting = 1;
        else if (humidity < 0)
            HumiditySetting = 0;
        else HumiditySetting = humidity;
    }
    public void SetTemperature(float temp)
    {
        // TODO: Return error message or something if out of range
        if (temp > 1)
            TempSetting = 1;
        else if (temp < 0)
            TempSetting = 0;
        else TempSetting = temp;
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
