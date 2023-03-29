using System;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
    private static Dictionary<LogCategory, string> logCategoryColors = new Dictionary<LogCategory, string>()
    {
        { LogCategory.Default,   "#ffffff" },
        { LogCategory.Core,      "#ff0000" },
        { LogCategory.Scenes,    "#00ff00" },
        { LogCategory.Camera,    "#0000ff" },
        { LogCategory.Content,   "#f0f000" },
        { LogCategory.Selection, "#f0f0f0" },
        { LogCategory.UI,        "#0f0000" },
        { LogCategory.Input,     "#0f0f00" },
    };

    public static void Log(LogCategory category, string message, object target = null)
    {
        Debug.Log($"[{Time.frameCount}] <color={logCategoryColors[category]}>{category}</color> --- {message}{(target == null ? "" : $" --- {target}")}");
    }

    public static void Log(object message, object target = null)
    {
        Debug.Log($"[{Time.frameCount}] <color=orange>DEBUG</color> --- {message}{(target == null ? "" : $" --- {target}")}");
    }

    public static void LogWarning(LogCategory category, string message, object target = null)
    {
        Debug.LogWarning($"[{Time.frameCount}] <color={logCategoryColors[category]}>{category}</color> --- {message}{(target == null ? "" : $" --- {target}")}");
    }

    public static void LogError(LogCategory category, string message, object target = null)
    {
        Debug.LogError($"[{Time.frameCount}] <color={logCategoryColors[category]}>{category}</color> --- {message}{(target == null ? "" : $" --- {target}")}");
    }

    public static void LogException(LogCategory category, Exception e, string message = null, object target = null)
    {
        Debug.LogError($"[{Time.frameCount}] <color={logCategoryColors[category]}>{category}</color> --- {e.Message}{(string.IsNullOrEmpty(message) ? "" : $" --- {message}")}{(target == null ? "" : $" --- {target}")}\n\n{e.StackTrace}");
    }
}

public enum LogCategory
{
    Default   = 0,
    Core      = 10,
    Scenes    = 20,
    Camera    = 30,
    Content   = 40,
    Selection = 50,
    UI        = 60,
    Input     = 70,
}