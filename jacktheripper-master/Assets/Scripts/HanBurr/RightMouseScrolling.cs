using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightMouseScrolling : MonoBehaviour
{
    bool zoom;
    public GameObject middle;
    Vector3 originalPos;
    private void Start()
    {
        zoom = false;
        originalPos = transform.position;
    }
    void Update()
    {
        if (zoom)
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 temp = new Vector3(transform.position.x, (Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime) + transform.position.y, transform.position.z);
                transform.GetComponent<RectTransform>().position = temp;
            }
            else
            {
                Vector3 lScale = transform.localScale;
                lScale.x += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 20;
                lScale.y = lScale.z = lScale.x;
                transform.localScale = lScale;
            }
        }
    }
    public void Klick()
    {
        if (zoom == true)
        {
            zoom = false;
            transform.position = originalPos;
            transform.localScale = new Vector3(1, 1);
        }
        else
        {
            zoom = true;
            transform.position = middle.transform.position;
            transform.localScale = new Vector3(1.2f, 1.2f);
        }
    }
}
