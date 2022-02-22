using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MapController : MonoBehaviour
{
    public Sprite bR;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;

    public GameObject photo;

    public void bucksRow()
    {
        photo.GetComponent<Image>().sprite = bR;
    }
    public void twoo()
    {
        photo.GetComponent<Image>().sprite = two;
    }
    public void threee()
    {
        photo.GetComponent<Image>().sprite = three;
    }
    public void fourr()
    {
        photo.GetComponent<Image>().sprite = four;
    }
    public void fivee()
    {
        photo.GetComponent<Image>().sprite = five;
    }
}