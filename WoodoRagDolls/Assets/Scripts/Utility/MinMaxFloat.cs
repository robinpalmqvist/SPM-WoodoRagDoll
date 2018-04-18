using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MinMaxFloat{

    public float Min;
    public float Max;

    public MinMaxFloat(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public override string ToString()
    {
        return "Max: " + Max + " Min: " + Min;
    }
}
