using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Handles Navigation of AR Objects 
//Taping, Zooming, Dragging

public class Navigation : MonoBehaviour
{

    //touch
    private Touch touch1, touch2;
    private float goalObjDist, fingerDistanceDiff;

    //dragging
    private Vector3 goalObjPos, goalObjOffset, offset;
    private bool dragging;

    //zooming
    public float zooming;
    private Vector3 zoomFactor, startingScale;
    private Vector2 fingerDist, fingerDistDelta;
    private float variance;

    //centering
    private Vector2 screenCenter;


    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        
        zoomFactor = new Vector3(zooming, zooming, zooming);
        variance = 5.0f;
        startingScale = this.transform.localScale;
        screenCenter = new Vector2((Screen.width/2),(Screen.height/2));
    }

    // Update is called once per frame
    void Update()
    {
        #region touching
        if (Input.touchCount > 0)
        {
            //Get touched Obj
            touch1 = Input.GetTouch(0);
            Ray ray1 = Camera.main.ScreenPointToRay(touch1.position);
            RaycastHit hit1;

            //Second touched Obj
            if (Input.touchCount > 1)
            {
                touch2 = Input.GetTouch(1);
                Ray ray2 = Camera.main.ScreenPointToRay(touch2.position);
            }

            switch (touch1.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(ray1, out hit1) && hit1.transform == this.transform)
                    {
                        goalObjDist = hit1.transform.position.z - Camera.main.transform.position.z;
                        goalObjPos = Camera.main.ScreenToWorldPoint(new Vector3(touch1.position.x, touch1.position.y, goalObjDist));
                        offset = hit1.transform.position - goalObjPos;
                        dragging = true;
                    }
                    break;

                case TouchPhase.Ended:
                    dragging = false;
                    break;

                case TouchPhase.Moved:
                    if (dragging)
                    {
                        goalObjPos = Camera.main.ScreenToWorldPoint(new Vector3(touch1.position.x, touch1.position.y, goalObjDist));
                        this.transform.position = goalObjPos + offset;
                    }
                    break;
            }
            switch (touch2.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Moved:
                    // Momentane Distanz
                    fingerDist = touch1.position - touch2.position;
                    // Distanz davor
                    fingerDistDelta = (touch1.position - touch1.deltaPosition) - (touch2.position - touch2.deltaPosition);
                    
                    fingerDistanceDiff = fingerDist.magnitude - fingerDistDelta.magnitude;

                    if (((fingerDistanceDiff + variance) <= 1) && (this.transform.localScale.x >= (startingScale.x + zoomFactor.x)))
                    {
                        this.transform.localScale -= zoomFactor;
                    }
                    else if (((fingerDistanceDiff + variance) > 1))
                    {
                        this.transform.localScale += zoomFactor;
                    }
                    break;
            }
        }
        #endregion
    }
}
