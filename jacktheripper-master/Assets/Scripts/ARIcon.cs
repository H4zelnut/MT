using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//on every gameobject that has a Vuforia Target
//makes camera icon visible, so you know when theres AR Stuff
public class ARIcon : MonoBehaviour
{
    public GameObject Kamera;
   
    private void OnEnable()
    {
        Kamera.SetActive(true);
    }
    private void OnDisable()
    {
        Kamera.SetActive(false);
    }
}
