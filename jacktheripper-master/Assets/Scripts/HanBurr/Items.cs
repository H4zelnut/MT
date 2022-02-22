using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handels rotation of door and house in HBS AR 
public class Items : MonoBehaviour
{
    //Touch
    private Touch touch;
    private float tapTime;
    //Rotations
    private float camSpeed;
    private int rotAngle;
    private bool doorAction, doorActionRev, houseAction;
    public bool houseActionRev;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        tapTime = 0f;
        camSpeed = 5f;
        rotAngle = 90;
        doorAction = false;
        houseAction = false;
        doorActionRev = false;
        houseActionRev = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            //Get touched Obj
            touch = Input.GetTouch(0);
            RaycastHit[] hits;
            tapTime += Time.deltaTime;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tapTime = 0;
                    break;

                case TouchPhase.Ended:
                    //if just taped
                    if (Input.touchCount<2)
                    {
                        int temp = 0;
                        hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(touch.position));
                        if (hits != null)
                        {
                            foreach (RaycastHit hit in hits)
                            {
                                temp += 1;
                                if (hit.transform.tag == "FrontDoor")
                                {
                                    doorAction = true;
                                    if (doorActionRev == true)
                                    {
                                        doorActionRev = false;
                                    }
                                    else
                                    {
                                        doorActionRev = true;
                                    }
                                    break;
                                }
                                else if (hit.transform.tag == "Arrow" && doorAction == true)
                                {
                                    hit.transform.rotation = new Quaternion(hit.transform.rotation.x + 180, hit.transform.rotation.y + 180, hit.transform.rotation.z, hit.transform.rotation.w);
                                    houseAction = true;
                                    if (houseActionRev == true)
                                    {
                                        houseActionRev = false;
                                    }
                                    else
                                    {
                                        houseActionRev = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
        }
        if (doorAction == true)
        {
            if (doorActionRev == true)
            {
                //door.transform.rotation = Quaternion.Slerp(door.transform.rotation, new Quaternion(door.transform.rotation.x, 110, door.transform.rotation.z, door.transform.rotation.w), Time.deltaTime * doorSpeed);
                door.SetActive(false);
            }
            else
            {
                door.SetActive(true);
                //door.transform.rotation = Quaternion.Slerp(door.transform.rotation, new Quaternion(door.transform.rotation.x, 0, door.transform.rotation.z, door.transform.rotation.w), Time.deltaTime * doorSpeed);
            }
        }
        if (houseAction == true)
        {
            if (houseActionRev == true)
            {
                this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, rotAngle, 0), Time.deltaTime * camSpeed);
            }
            else
            {
                this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -rotAngle, 0), Time.deltaTime * camSpeed);
            }
        }
        if (this.transform.rotation.x == rotAngle || this.transform.rotation.x == 0)
        {
            houseAction = false;
        }
    }

}
