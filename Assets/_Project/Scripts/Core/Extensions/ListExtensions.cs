using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ListExtensions
{
    public static T RandomElement<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static float SafeMin<T>(this List<T> list, Func<T, float> selector)
    {
        return list.Count > 0 ? list.Min(selector) : 0f;
    }
    public static float SafeMax<T>(this List<T> list, Func<T, float> selector)
    {
        return list.Count > 0 ? list.Max(selector) : 0f;
    }
    public static float SafeAverage<T>(this List<T> list, Func<T, float> selector)
    {
        return list.Count > 0 ? list.Average(selector) : 0f;
    }
}