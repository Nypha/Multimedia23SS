using UnityEngine;

public static class StringExtensions
{
    public static string Color(this string origin, Color color)
    {
        return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{origin}</color>";
    }
    public static string Italic(this string origin)
    {
        return $"<i>{origin}</i>";
    }
    public static string Bold(this string origin)
    {
        return $"<b>{origin}</b>";
    }
    public static string Size(this string origin, int size)
    {
        return "<size=" + size + ">" + origin + "</size>";
    }

    public static bool ContainsAny(this string origin, params string[] strings)
    {
        foreach (var s in strings)
        {
            if (origin.Contains(s))
            {
                return true;
            }
        }

        return false;
    }
    public static bool ContainsAll(this string origin, params string[] strings)
    {
        foreach (var s in strings)
        {
            if (!origin.Contains(s))
            {
                return false;
            }
        }

        return true;
    }
}