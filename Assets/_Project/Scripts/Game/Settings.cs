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
}
