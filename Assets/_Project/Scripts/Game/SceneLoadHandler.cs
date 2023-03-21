using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "Game_Scene")
            {
                enabled = false; // Prevents button smashing
                SceneManager.LoadSceneAsync("Menu_Scene");
            }
            else if (SceneManager.GetActiveScene().name == "Menu_Scene")
            {
                enabled = false;
                SceneManager.LoadSceneAsync("Game_Scene");
            }
        }
    }
}
