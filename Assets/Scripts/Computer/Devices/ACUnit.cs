using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ACUnit : Device
{
    public Atmosphere Atmosphere;
    public TemperatureSensor[] TemperatureSensors;
    public HumiditySensor[] HumiditySensors;

    public static float MaximumTemperature = 310;
    public static float MinimumTemperature = 280;

    public float HeatRate = 1;
    public float HumidifyRate = 0.01f;

    public float HumiditySetting { get; private set; } = 0.1f;
    public float TempSetting { get; private set; } = 0.5f;
    public bool StartAtSettings = true;

    void Update()
    {
        // TODO: Schedule on/off periods with a minimum delay between
        double targetTemp = GetTempFromSetting();
        double currentTemp = GetTemperature();
        double currentHumidity = GetHumidity();

        if (targetTemp != currentTemp)
            HeatOrCoolToSetting();

        if (Atmosphere.Humidity != currentHumidity)
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

    private double GetTemperature()
    {
        return TemperatureSensors.Select(s => s.GetTemperature()).Sum() /
            TemperatureSensors.Length;
    }
    private double GetHumidity()
    {
        return HumiditySensors.Select(s => s.GetHumidity()).Sum() /
            HumiditySensors.Length;
    }
    private void HeatOrCoolToSetting()
    {
        double targetTemp = GetTempFromSetting();
        double tempChange = HeatRate / Atmosphere.Volume;
        double diff = targetTemp - Atmosphere.Temperature;
        if (diff == 0) return;
        // if (Mathf.Abs((float) diff) < tempChange)
            // Atmosphere.Temperature = targetTemp;
        // else if (diff > 0)
            // Atmosphere.Temperature += tempChange;
        // else Atmosphere.Temperature -= tempChange;
    }
    private void HumidifyToSetting()
    {
        double humidChange = HumidifyRate / Atmosphere.Volume;
        double diff = HumiditySetting - Atmosphere.Humidity;
        if (diff == 0) return;
        // if (Mathf.Abs(diff) < humidChange)
        //     Atmosphere.Humidity = HumiditySetting;
        // else if (diff > 0)
        //     Atmosphere.Humidity += humidChange;
        // else Atmosphere.Humidity -= humidChange;
    }
    private double GetTempFromSetting()
    {
        float tempRange = MaximumTemperature - MinimumTemperature;
        return TempSetting * tempRange + MinimumTemperature;
    }
}
