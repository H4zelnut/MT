using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handels Letter opening/closing
public class DearBoss : MonoBehaviour
{
    public GameObject front, back;

    //Dear Boss (has two pages)
    public void Letter()
    {
        front.SetActive(true);
        back.SetActive(true);
    }
    public void Close()
    {
        front.SetActive(false);
        back.SetActive(false);
    }
    // Saucy Jack
    // From Hell 
    // Have one page
    public void PostCard()
    {
        front.SetActive(true);
    }
    public void CloseCard()
    {
        front.SetActive(false);
    }
}
