using UnityEngine;
using UnityEngine.Audio;

public class MusicHandler : MonoBehaviour
{
    public static MusicHandler Instance { get; private set; }


    public AudioMixerGroup mixer;
    // public AudioSource audioSource;
    // public AudioClip music;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;

        // audioSource.
        // audioSource.clip = music;
        // audioSource.Play();
    }
}
