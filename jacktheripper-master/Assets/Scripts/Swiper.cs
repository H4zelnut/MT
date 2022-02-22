using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swiper : MonoBehaviour
{
    public GameObject middle, upper, lower;
    bool m, u, l;
    private Vector3 midLocation, upLocation, lowLocation;
    float speed, height;
    bool movingUp, movingDown;

    // Start is called before the first frame update
    void Start()
    {
        m = true;
        u = false;
        l = false;

        height = middle.GetComponent<RectTransform>().rect.height;
        upper.transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y + height, middle.transform.position.z);
        lower.transform.position = new Vector3(middle.transform.position.x, middle.transform.position.y - height, middle.transform.position.z);

        midLocation = middle.transform.position;
        upLocation = upper.transform.position;
        lowLocation = lower.transform.position;

        speed = 10.0f;

        movingDown = false;
        movingUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && movingDown == false && movingDown == false)
        {
            if (!u)
            {
                movingUp = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && movingDown == false && movingDown == false)
        {
            if (!l)
            {
                movingDown = true;
            }
        }
        if (movingUp)
        {
            middle.transform.position -= new Vector3(0, speed, 0);
            lower.transform.position -= new Vector3(0, speed, 0);
            upper.transform.position -= new Vector3(0, speed, 0);

            if (m == true && upper.transform.position.y <= midLocation.y)
            {
                u = true;
                m = false;
                movingUp = false;
            }
            else if (l == true && middle.transform.position.y <= midLocation.y)
            {
                m = true;
                l = false;
                movingUp = false;
            }
        }
        else if (movingDown)
        {
            middle.transform.position += new Vector3(0, speed, 0);
            lower.transform.position += new Vector3(0, speed, 0);
            upper.transform.position += new Vector3(0, speed, 0);

            if (m == true && lower.transform.position.y >= midLocation.y)
            {
                m = false;
                l = true;
                movingDown = false;
            }
            else if (u == true && middle.transform.position.y >= midLocation.y)
            {
                m = true;
                u = false;
                movingDown = false;
            }
        }
    }
}
