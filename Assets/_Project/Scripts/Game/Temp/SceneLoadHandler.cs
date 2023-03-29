using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadHandler : MonoBehaviour
{
    private void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (SceneManager.GetActiveScene().name == "Game_Scene")
            {
                SceneManager.LoadSceneAsync("Menu_Scene");
            }
            else if (SceneManager.GetActiveScene().name == "Menu_Scene")
            {
                SceneManager.LoadSceneAsync("Game_Scene");
            }
        }
    }
}
