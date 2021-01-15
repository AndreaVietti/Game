using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public Button menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(goToMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
