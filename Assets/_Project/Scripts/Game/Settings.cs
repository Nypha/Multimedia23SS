using UnityEngine;

public static class Settings
{
    public static float Volume 
    {
        get => volume;
        set 
        {
            volume = value;
            MusicHandler.Instance.mixer.audioMixer.SetFloat("_MasterVolume", Mathf.Log(value) * 20);
        } 
    }
    private static float volume = 1f;
    public static string PlayerName { get; set; } = "Player 1";

    public static bool PlayerCustomizationDirty { get; set; }
    public static bool HasShoes { get; set; }
    public static bool HasPants { get; set; }
    public static bool HasPullover { get; set; }
    public static Color StyleShoes { get; set; }
    public static Color StylePants { get; set; }
    public static Color StylePullover { get; set; }
}
