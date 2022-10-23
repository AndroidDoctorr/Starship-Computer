using Assets.Scripts.Computer;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstrictionCoils : Device
{
    private double timeSinceSwitch = 0;
    private int coilIndex = 0;

    public List<Renderer> Coils;
    public Material LitMaterial;
    public Material DimMaterial;

    public double Draw
    {
        get
        {
            return 5;
        }
    }
    void Start()
    {

    }

    void Update()
    {
        timeSinceSwitch += Time.deltaTime;
        if (timeSinceSwitch >= 0.2)
        {
            SwitchLitPosition();
            timeSinceSwitch = 0;
        }
    }

    private void SwitchLitPosition()
    {
        int prevCoilIndex = coilIndex--;
        if (coilIndex == -1)
        {
            coilIndex = 14;
        }

        Coils[prevCoilIndex].material = DimMaterial;
        Coils[coilIndex].material = LitMaterial;
    }
}
