using System.Collections;
using UnityEngine;

public static class FloatExtensions
{
    public static float Remap(this float value, float low1 = 0f, float high1 = 1f, float low2 = 0f, float high2 = 1f)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }

    public static Vector2 ToVector2(this float value)
    {
        return new Vector2(value, value);
    }
    public static Vector3 ToVector3(this float value)
    {
        return new Vector3(value, value, value);
    }
}