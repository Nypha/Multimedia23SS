using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class VectorExtension
{
    /// <summary>
    /// Sets the y coordinate of the vector to 0.
    /// </summary>
    public static Vector3 Flat(this Vector3 origin)
    {
        return new Vector3(origin.x, 0f, origin.z);
    }

    /// <summary>
    /// Lets you set one or multiple values of the vector.
    /// </summary>
    public static Vector3 With(this Vector3 origin, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? origin.x, y ?? origin.y, z ?? origin.z);
    }

    /// <summary>
    /// Checks if a vector is within given bounds.
    /// </summary>
    public static bool IsWithin(this Vector3 origin,
        float minX = float.MinValue, float minY = float.MinValue, float minZ = float.MinValue,
        float maxX = float.MaxValue, float maxY = float.MaxValue, float maxZ = float.MaxValue)
    {
        return origin.x >= minX && origin.y >= minY && origin.z >= minZ &&
            origin.x <= maxX && origin.y <= maxY && origin.z <= maxZ;
    }

    /// <summary>
    /// Checks if a vector is within given vectors.
    /// </summary>
    public static bool IsWithin(this Vector3 origin, Vector3 bottomLeft, Vector3 topRight)
    {
        return origin.x >= bottomLeft.x && origin.y >= bottomLeft.y && origin.z >= bottomLeft.z &&
            origin.x <= topRight.x && origin.y <= topRight.y && origin.z <= topRight.z;
    }

    /// <summary>
    /// Checks if a vector is within the radius of a given point.
    /// </summary>
    public static bool IsWithin(this Vector3 origin, Vector3 point, float radius)
    {
        // return Vector3.Distance(origin, point) <= radius;
        return (origin - point).sqrMagnitude <= radius * radius;
    }

    /// <summary>
    /// Tells whether one of the three vector values is NaN.
    /// </summary>
    public static bool IsNaN(this Vector3 origin)
    {
        return float.IsNaN(origin.x) || float.IsNaN(origin.y) || float.IsNaN(origin.z);
    }

    /// <summary>
    /// Tells whether one of the three vector values is Infinity, NegativeInfinity or PositiveInfinity.
    /// </summary>
    public static bool IsInfinity(this Vector3 origin)
    {
        return float.IsInfinity(origin.x) || float.IsInfinity(origin.y) || float.IsInfinity(origin.z) ||
               float.IsNegativeInfinity(origin.x) || float.IsNegativeInfinity(origin.y) || float.IsNegativeInfinity(origin.z) ||
               float.IsPositiveInfinity(origin.x) || float.IsPositiveInfinity(origin.y) || float.IsPositiveInfinity(origin.z);
    }

    /// <summary>
    /// Rounds every dimension of the vector and returns it.
    /// </summary>
    public static Vector3 Round(this Vector3 origin)
    {
        return new Vector3(
            Mathf.Round(origin.x),
            Mathf.Round(origin.y),
            Mathf.Round(origin.z)
            );
    }

    /// <summary>
    /// Rounds every dimension of the vector up and returns it.
    /// </summary>
    public static Vector3 Ceil(this Vector3 origin)
    {
        return new Vector3(
            Mathf.Ceil(origin.x),
            Mathf.Ceil(origin.y),
            Mathf.Ceil(origin.z)
            );
    }

    /// <summary>
    /// Returns the max out of x, y, and z.
    /// </summary>
    public static float Max(this Vector3 origin)
    {
        return Mathf.Max(origin.x, origin.y, origin.z);
    }

    /// <summary>
    /// Returns the max out of x and z.
    /// </summary>
    public static float MaxXZ(this Vector3 origin)
    {
        return Mathf.Max(origin.x, origin.z);
    }

    /// <summary>
    /// Returns the <b>squared</b> distance on the XZ plane between this and the other vector.
    /// </summary>
    public static float SqrDistanceXZ(this Vector3 origin, Vector3 other)
    {
        float x = other.x - origin.x;
        float z = other.z - origin.z;
        return x * x + z * z;
    }

    /// <summary>
    /// Retuns the absolute values of this vector.
    /// </summary>
    public static Vector3 Abs(this Vector3 origin)
    {
        return new Vector3(Mathf.Abs(origin.x), Mathf.Abs(origin.y), Mathf.Abs(origin.z));
    }


    /// <summary>
    /// Returns a Vector2 containing the X and Z coordinate of this vector.
    /// </summary>
    public static Vector2 XZ(this Vector3 origin)
    {
        return new Vector2(origin.x, origin.z);
    }

    /// <summary>
    /// Returns a Vector2 containing the X and Z coordinate of this vector. If the converter is null, the floats are rounded to int.
    /// </summary>
    public static Vector2Int XZInt(this Vector3 origin, Func<float, int> converter = null)
    {
        if (converter == null)
        {
            return new Vector2Int(Mathf.RoundToInt(origin.x), Mathf.RoundToInt(origin.z));
        }
        else
        {
            return new Vector2Int(converter(origin.x), converter(origin.z));
        }
    }

    /// <summary>
    /// Returns a random value within x and y of the vector.
    /// </summary>
    public static float GetRandom(this Vector2 origin)
    {
        return Random.Range(origin.x, origin .y);
    }

    /// <summary>
    /// Returns a random value within x and y of the vector.
    /// </summary>
    public static int GetRandom(this Vector2Int origin)
    {
        return Random.Range(origin.x, origin.y + 1);
    }
}
