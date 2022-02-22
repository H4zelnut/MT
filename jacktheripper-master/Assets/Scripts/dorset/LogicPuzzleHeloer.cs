using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPuzzleHeloer : MonoBehaviour
{
    public GameObject firstFloor, gfOverlay;
    bool fF;
    Gyroscope m_Gyro;
    private void Start()
    {
        fF = false;
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }
    private void Update()
    {
        if(m_Gyro.rotationRate.x > 2.0)
        {
            //nach oben
            if(fF == false)
            {
                fF = true;
                firstFloor.SetActive(true);
                gfOverlay.SetActive(false);
            }
        }
        if(m_Gyro.rotationRate.x < -2.0)
        {
            //nach unten
            if(fF == true)
            {
                fF = false;
                firstFloor.SetActive(false);
                gfOverlay.SetActive(true);
            }
        }
    }
}
