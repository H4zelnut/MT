using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Zooms an Object when hovered over it and mouse wheel turns
public class VufZoom : MonoBehaviour
{
    //safe initial state 
    //when mouse leafes object > return to initial state
    Vector3 initialSize;
    Vector3 initialPos;
    
    void Start()
    {
        initialPos = new Vector3(0f,0f,0f);
        initialPos = transform.position;
        initialSize = new Vector3(0f, 0f, 0f);
        initialSize = transform.localScale;
    }

    
    void Update()
    {
        if (this.gameObject.GetComponent<BoxCollider2D>().bounds.Contains(Input.mousePosition)){
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
        else
        {
            transform.position = initialPos;
            transform.localScale = initialSize;
        }
    }
}
