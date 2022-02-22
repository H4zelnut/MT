using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//HBS Letter Opener
public class LetterBehavior : MonoBehaviour
{
    public GameObject Letter;
    public Sprite closed, open;

    public void ChangeStatus()
    {
        if (Letter.GetComponent<Image>().sprite == open)
        {
            Letter.GetComponent<Image>().sprite = closed;
            Letter.SetActive(false);
        }
        else
        {
            Letter.GetComponent<Image>().sprite = open;
        }
    }
}
