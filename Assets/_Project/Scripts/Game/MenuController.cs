using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject contentMenu;
    public Button bnPlay;
    public Button bnExit;
    public TMP_InputField inputField;
    public Slider slider;
    public TextMeshProUGUI tfVolume;
    [Space]
    public GameObject contentLoad;


    private void Start()
    {
        bnPlay.onClick.AddListener(OnPlay);
        bnExit.onClick.AddListener(OnExit);
        slider.onValueChanged.AddListener(OnSetVolume);
        slider.SetValueWithoutNotify(Settings.Volume);
        inputField.onValueChanged.AddListener(OnSetPlayerName);
        inputField.SetTextWithoutNotify(Settings.PlayerName);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnSetPlayerName(string arg0)
    {
        Settings.PlayerName = arg0;
    }

    private void OnSetVolume(float arg0)
    {
        Settings.Volume = arg0;
        tfVolume.text = $"{arg0 * 100:n0}%";
    }

    private void OnExit()
    {
        if (!Application.isEditor)
        {
            Application.Quit();
        }
    }

    private void OnPlay()
    {
        SceneManager.LoadScene("Game_Scene");
        contentMenu.SetActive(false);
        contentLoad.SetActive(true);
    }
}
