using UnityEngine;

public class Player : MonoBehaviour
{
    public int measureCompare;

    public string nome { get; set; }
    public string timer { get; set; }

    public Player()
    {

    }
    public Player(string nome, string timer)
    {
        this.nome = nome;
        this.timer = timer;
        string[] measure = timer.Split(':');
        measureCompare = int.Parse(measure[0]) * 60;
        string[] misuraSec = measure[1].Split('.');
        measureCompare += int.Parse(misuraSec[0]);
        measureCompare += int.Parse(misuraSec[1]) / 100;
    }
}
