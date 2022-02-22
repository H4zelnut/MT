using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class DialogueMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Color colorNew;
    Color colorOld;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        colorOld = text.color;
        colorNew = Color.green;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = colorNew;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = colorOld;
    }
}
