using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuTutorial : MonoBehaviour
{
    public Button menu;
    public Button quit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        menu.onClick.AddListener(goToMenu);
        quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
