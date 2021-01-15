using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    public Button play;
    public Button tutorial;
    public Button settings;
    public Button quit;

    void Start()
    {
        Button btn = play.GetComponent<Button>();
        btn.onClick.AddListener(goToGame);

        Button btn1 = tutorial.GetComponent<Button>();
        btn1.onClick.AddListener(goToTutorial);

        Button btn2 = settings.GetComponent<Button>();
        btn2.onClick.AddListener(goToSettings);

        Button btn3 = quit.GetComponent<Button>();
        btn3.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void goToGame()
    {
        SceneManager.LoadScene("Map_v1");
    }

    void goToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    void goToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}