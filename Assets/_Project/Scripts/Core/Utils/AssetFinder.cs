using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dreihaus.Utils
{
    public class AssetFinder
    {
        public static IEnumerable<T> Find<T>() where T : Object
        {
#if UNITY_EDITOR
            var data = new HashSet<T>();

            var type = typeof(T).Name;
            var paths = AssetDatabase.FindAssets($"t:{type}");
            foreach (var guid in paths)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var item = AssetDatabase.LoadAssetAtPath<T>(path);
                data.Add(item);
            }

            return data;
#else
        Debug.LogError("AssetFinder.Find<T>() must not be called outside the editor!");
        return new List<T>();
#endif
        }
        public static T FindFirst<T>() where T : Object
        {
#if UNITY_EDITOR
            var found = Find<T>();
            if (found.Count() > 0)
            {
                return found.ElementAt(0);
            }
            else
            {
                return null;
            }
#else
        Debug.LogError("AssetFinder.FindFirst<T>() must not be called outside the editor!");
        return default;
#endif
        }
    }
}