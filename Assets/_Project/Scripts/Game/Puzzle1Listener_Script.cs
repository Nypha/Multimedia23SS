using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puzzle1Listener_Script : MonoBehaviour
{

    PuzzleRoom1 room1;
    public GameObject[] WD40s;
    public AudioSource solvedSound;
    public bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        WD40s = GameObject.FindGameObjectsWithTag("WD40");
        room1 = GetComponent<PuzzleRoom1>();
        GameSceneManager.Instance.OnResetScene += OnResetScene;
    }

    // Update is called once per frame
    void Update()
    {
        bool solved = true;
        foreach (GameObject WD40 in WD40s)
        {
            if (!WD40.GetComponent<PuzzleRoom1_WD40>().isPickedUp)
                if (!WD40.GetComponent<PuzzleRoom1_WD40>().isPickedUp)
                {
                    solved = false;
                    break;
                }
        }
        room1.isComplete = solved;

        if (solved && !soundPlayed)
        {
            solvedSound.Play();
            soundPlayed = true;
        }
    }

    private void OnResetScene()
    {
        ResetSound();
    }
    public void ResetSound()
    {
        soundPlayed = false;
    }

}
