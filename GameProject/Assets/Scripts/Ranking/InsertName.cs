using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsertName : MonoBehaviour
{
    public InputField inp;
    public Button menu;
    public Button quit;
    public Button play;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Button btn = menu.GetComponent<Button>();
        btn.onClick.AddListener(goToMenu);

        Button btn2 = quit.GetComponent<Button>();
        btn2.onClick.AddListener(QuitGame);

        Button btn3 = play.GetComponent<Button>();
        btn3.onClick.AddListener(goToPlay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void goToPlay()
    {
        SceneManager.LoadScene("Map_v1");
        Debug.Log(inp.text.ToString());
        StartMenu.player.nome = inp.text.ToString();
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
