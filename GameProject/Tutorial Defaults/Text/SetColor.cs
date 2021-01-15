using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;
    public Image black;
    public Image red;

    void Start() 
    {
        red.enabled = false;
        black.enabled = true;
    }

    void update() {
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        if (isOver)
        {
            red.enabled = true;
            black.enabled = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        if (!isOver)
        {
            red.enabled = false;
            black.enabled = true;
        }
    }

}
