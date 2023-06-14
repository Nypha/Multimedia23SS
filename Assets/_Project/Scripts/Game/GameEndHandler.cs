using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndHandler : MonoBehaviour
{
    public void EndGame()
    {
        GameUI.Instance.ShowGameEndScreen();
        GameSceneManager.Instance.StopTimer();
    }
}
