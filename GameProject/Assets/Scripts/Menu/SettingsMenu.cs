using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public Toggle isFullScreen;

    public Button BackButton;

    private void Start()
    {
        Button btn = BackButton.GetComponent<Button>();
        btn.onClick.AddListener(goBackMenu);
        //isFullScreen.isOn = false;
        
    }

    void Update() {
        SetFullscreen(isFullScreen.isOn);
    }

    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void goBackMenu() {
        SceneManager.LoadScene("Menu");
    }
}