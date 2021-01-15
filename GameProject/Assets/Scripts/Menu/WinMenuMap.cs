using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuMap : MonoBehaviour
{
    public Button menu;
    public Button quit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        FileStream fs = new FileStream(@"Classifica.txt", FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(fs);
        writer.WriteLine(StartMenu.player.nome + "#" + StartMenu.player.timer);
        writer.Close();
        fs.Close();

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
