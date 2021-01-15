using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    [SerializeField]
    private GameObject life;
    [SerializeField]
    private float percentualeVitaTolta = 25f;
    private float valAssVitaTolta;
    // Use this for initialization
    void Start()
    {
        valAssVitaTolta = life.transform.localScale.x * percentualeVitaTolta / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (life.transform.localScale.x <= 0)
        {
            //fai partitre altra scena in cui scrivi morto
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Hostage"))
        {
            if (life.transform.localScale.x >= 0) {
                life.transform.localScale = new Vector3(life.transform.localScale.x - valAssVitaTolta, life.transform.localScale.y, life.transform.localScale.z);
            }
        }
    }
}
