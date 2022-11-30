using Assets.Scripts.Computer;
using Assets.Scripts.Computer.Systems.Environment;
using Assets.Scripts.Computer.Systems.Environment.SubSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ACUnit : Device
{
    public Atmosphere Atmosphere;
    public AtmosphereGroup AtmosphereGroup;

    public static double MaximumTemperature = 310;
    public static double MinimumTemperature = 280;

    public double HeatRate = 1;
    public double HumidifyRate = 0.01f;

    public double HumiditySetting { get; private set; } = 0.1f;
    public double TempSetting { get; private set; } = 0.5f;
    public bool StartAtSettings = true;

    void Update()
    {
        // TODO: Schedule on/off periods with a minimum delay between
        double targetTemp = GetTempFromSetting();
        double currentTemp = AtmosphereGroup.GetTemperature();
        double currentHumidity = AtmosphereGroup.GetHumidity();

        if (targetTemp != currentTemp)
            HeatOrCoolToSetting();

        if (Atmosphere.Humidity != currentHumidity)
            HumidifyToSetting();
    }

    public void SetHumidity(double humidity)
    {
        // TODO: Return error message or something if out of range
        if (humidity > 1)
            HumiditySetting = 1;
        else if (humidity < 0)
            HumiditySetting = 0;
        else HumiditySetting = humidity;
    }
    public void SetTemperature(double temp)
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
        double targetTemp = GetTempFromSetting();
        double currentTemp = AtmosphereGroup.GetTemperature();
        double diff = targetTemp - currentTemp;
        if (diff == 0) return;
        // Remaining heat needed to meet target temp
        double qToGo = Atmosphere.GetHeatDifference(targetTemp);
        if (Mathf.Abs((float) qToGo) < HeatRate)
            Atmosphere.AddHeat(qToGo);
        else if (targetTemp < currentTemp) 
            Atmosphere.AddHeat(-HeatRate);
        else Atmosphere.AddHeat(HeatRate);
    }
    private void HumidifyToSetting()
    {
        double currentHumidity = AtmosphereGroup.GetHumidity();
        double diff = HumiditySetting - currentHumidity;
        if (diff == 0) return;
        // Remaining water mass needed to meet target humidity
        double massToGo = Atmosphere.GetMoistureDifference(HumiditySetting);
        if (Mathf.Abs((float)massToGo) < HumidifyRate)
            Atmosphere.AddHumidity (massToGo);
        else if (HumiditySetting < currentHumidity)
            Atmosphere.AddHumidity(-HumidifyRate);
        else Atmosphere.AddHumidity(HumidifyRate);
    }
    private double GetTempFromSetting()
    {
        double tempRange = MaximumTemperature - MinimumTemperature;
        return TempSetting * tempRange + MinimumTemperature;
    }
}
