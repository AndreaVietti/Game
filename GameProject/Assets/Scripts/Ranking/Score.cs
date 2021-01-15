using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private List<string> l;
    public GameObject Area;
    public Score(List<string> a)
    {
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        string s;
        FileStream fs = new FileStream(@"Classifica.txt", FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(fs);
        List<Player> list = new List<Player>();
        while ((s = reader.ReadLine()) != null)
        {
            string[] a = s.Split('#');
            list.Add(new Player(a[0], a[1]));
        }
        list.Sort((x, y) => x.measureCompare.CompareTo(y.measureCompare));
        int position = 0;
        //StringBuilder ss = new StringBuilder();
        List<string> stringList = new List<string>();
        foreach (Player g in list)
        {
            position++;
            //ss.Append(" " + posizione + " " + g.nome + " " + g.timer + "\n");
            stringList.Add(position + "\t\t" + g.nome + "\t" + g.timer + "\n");
        }
        //Score w = new Score(ss.ToString());
        reader.Close();
        fs.Close();
        //
        //
        //
        List<string> list2 = new List<string>();
        list2.Add("Rank \t\t Nome \t Tempo");
        foreach (string c in stringList)
        {
            list2.Add(c);
        }
        int hight = (int)(Screen.height * 0.35);
        int length = (int)(Screen.width * 0.47);

        foreach (string temp in list2)
        {
            string text = temp;
            text = GUI.TextField(new Rect(265, hight, length, 20), text, 250);
            hight += 20;
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
