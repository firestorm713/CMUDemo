using UnityEngine;
using System.Collections;

public static class Common
{
    public static float Interpolate(float start, float end, float percentage)
    {
        return (start * (1 - percentage) + end * percentage);
    }
}
