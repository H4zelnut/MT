using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Papers : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler
{
    public GameObject shadow;
    public GameObject middlePoint;
    private bool moving = false;
    private bool focused = false;

    // get initial pos and rot
    Vector3 pos;
    Quaternion rot;
    Vector3 scale;
    Vector3 posShadow;
    Quaternion rotShadow;
    Vector3 scaleShadow;
    Vector3 posMiddlePoint;
    Quaternion rotMiddlePoint;

    void Start()
    {
        pos = this.gameObject.transform.position;
        rot = this.gameObject.transform.rotation;
        scale = this.gameObject.transform.localScale;

        posShadow = shadow.gameObject.transform.position;
        rotShadow = shadow.gameObject.transform.rotation;
        scaleShadow = this.gameObject.transform.localScale;

        posMiddlePoint = middlePoint.gameObject.transform.position;
        rotMiddlePoint = middlePoint.gameObject.transform.rotation;
    }

    void Update ()
    {
        if (moving == true)
        {
            // wird schon gezoomt angezeigt
            if (focused)
            {
                MoveObject(pos, rot, scale / 3, scaleShadow / 3);
                if (this.gameObject.transform.position == pos)
                {
                    moving = false;
                    focused = false;
                }
            }
            // noch nicht gezoomt
            else
            {
                MoveObject(posMiddlePoint, rotMiddlePoint, scale * 3, scaleShadow * 3);
                if (this.gameObject.transform.position == posMiddlePoint)
                {
                    moving = false;
                    focused = true;
                }
            }
        }
    }
    void MoveObject (Vector3 posGoal, Quaternion rotGoal, Vector3 scale, Vector3 scaleShadow)
    {
        //position
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, posGoal, 400f * Time.deltaTime);
        shadow.gameObject.transform.position = Vector3.MoveTowards(shadow.gameObject.transform.position, posGoal, 400f * Time.deltaTime);
        //rotation
        this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, rotGoal, Time.time * 0.04f);
        shadow.gameObject.transform.rotation = Quaternion.Lerp(shadow.gameObject.transform.rotation, rotGoal, Time.time * 0.04f);
        //scale
        this.gameObject.transform.localScale = Vector3.MoveTowards(transform.localScale, scale, 10f * Time.deltaTime);
        shadow.gameObject.transform.localScale = Vector3.MoveTowards(transform.localScale, scaleShadow, 10f * Time.deltaTime);
    }
    #region events
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (!moving)
        {
            moving = true;
        }
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        shadow.SetActive(true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        shadow.SetActive(false);
    }
    #endregion
}
