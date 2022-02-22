using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool tutorial = true;
    public GameObject theStart, panel;

    public void Tutorials()
    {
        if (tutorial)
        {
            theStart.SetActive(true);
            panel.SetActive(true);
            tutorial = false;
        }
    }
}
