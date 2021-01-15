using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    public Button play;
    public Button tutorial;
    public Button gameRule;
    public Button settings;
    public Button quit;
    public Button ranking;
    public static Player player = new Player();
    string s;

    void Start()
    {
        Button btn = play.GetComponent<Button>();
        btn.onClick.AddListener(goToInsertName);

        Button btn1 = tutorial.GetComponent<Button>();
        btn1.onClick.AddListener(goToTutorial);

        Button btn2 = settings.GetComponent<Button>();
        btn2.onClick.AddListener(goToSettings);

        Button btn3 = quit.GetComponent<Button>();
        btn3.onClick.AddListener(QuitGame);

        Button btn4 = gameRule.GetComponent<Button>();
        btn4.onClick.AddListener(goToRules);

        Button btn5 = ranking.GetComponent<Button>();
        btn5.onClick.AddListener(goToScore);
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void goToInsertName()
    {
        SceneManager.LoadScene("InsertName");
    }

    void goToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    void goToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    void goToRules()
    {
        SceneManager.LoadScene("Rule");
    }


    void QuitGame()
    {
        Application.Quit();
    }

    private void goToScore()
    {
        SceneManager.LoadScene("Score");
        FileStream fs = new FileStream(@"Classifica.txt", FileMode.Open, FileAccess.Read);
        StreamReader leggi = new StreamReader(fs);
        List<Player> lista = new List<Player>();
        while ((s = leggi.ReadLine()) != null)
        {
            string[] a = s.Split('#');
            lista.Add(new Player(a[0], a[1]));
        }
        lista.Sort((x, y) => x.timer.CompareTo(y.timer));
        int posizione = 0;
        HiScoreScript sc = new HiScoreScript();
        //StringBuilder ss = new StringBuilder();
        List<string> listaStringhe = new List<string>();
        foreach (Player g in lista)
        {
            posizione++;
            //ss.Append(" " + posizione + " " + g.nome + " " + g.timer + "\n");
            listaStringhe.Add(posizione + " " + g.nome + " " + g.timer + "\n");
        }
        //Score w = new Score(ss.ToString());
        Score w = new Score(listaStringhe);
        leggi.Close();
        fs.Close();
    }
}