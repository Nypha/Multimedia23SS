using System.Collections.Generic;

public static class DictionaryExtensions
{
    public static void AddSafely<T, U>(this Dictionary<T, List<U>> dictionary, T key, U value)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, new List<U>());
        }
        dictionary[key].Add(value);
    }
    public static void AddSafely<T, U, V>(this Dictionary<T, Dictionary<U, List<V>>> dictionary, T key0, U key1, V value)
    {
        if (!dictionary.ContainsKey(key0))
        {
            dictionary.Add(key0, new Dictionary<U, List<V>>());
        }
        dictionary[key0].AddSafely(key1, value);
    }
}