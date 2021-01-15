using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRule : MonoBehaviour
{

    public Button menu;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Button btn = menu.GetComponent<Button>();
        btn.onClick.AddListener(goToMenu);

        Button btn2 = quit.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGame);
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
