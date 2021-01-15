using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreScript : MonoBehaviour
{
    public GameObject Tempo;
    public GameObject Nome;
    public GameObject rank;
    public HiScoreScript()
    {
    }
    public void SetScore(string rank, string Nome, string Tempo)
    {
        this.rank.GetComponent<Text>().text = rank;
        this.Nome.GetComponent<Text>().text = Nome;
        this.Tempo.GetComponent<Text>().text = Tempo;
    }
}
