using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Behavior Controller of findable Objects in AR Scene
//Clips Sprites of found Obj onto Canvas to Display

public class Objects : MonoBehaviour
{
    //Touch
    private Touch touch;
    private float tapTime;
    private float tapTimeThreshold;

    //Canvas
    public Text text;
    public GameObject canvas, back, comb, stains, mud, towel, mirror;

    //already touched
    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        tapTime = 0f;
        tapTimeThreshold = 5f;
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            canvas.SetActive(true);
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
                    if (tapTime <= tapTimeThreshold)
                    {
                        int temp = 0;
                        hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(touch.position));
                        if (hits != null)
                        {
                            foreach (RaycastHit hit in hits)
                            {
                                temp += 1;
                                if (hit.transform.tag == "Findables" && open == false)
                                {
                                    canvas.SetActive(true);
                                    back.SetActive(true);
                                    switch (hit.transform.name)
                                    {
                                        case "Comb":
                                            comb.SetActive(true);
                                            text.text = "A Comb";
                                            text.gameObject.SetActive(true);
                                            break;
                                        case "Stains":
                                            stains.SetActive(true);
                                            text.text = "Blood Stains";
                                            text.gameObject.SetActive(true);
                                            break;
                                        case "Mud":
                                            mud.SetActive(true);
                                            text.text = "Mud without traces";
                                            text.gameObject.SetActive(true);
                                            break;
                                        case "Towel":
                                            towel.SetActive(true);
                                            text.text = "A handkerchief";
                                            text.gameObject.SetActive(true);
                                            break;
                                        case "Mirror":
                                            mirror.SetActive(true);
                                            text.text = " A mirror";
                                            text.gameObject.SetActive(true);
                                            break;
                                    }
                                    open = true;
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }

    //Closes panel overlay on BR Canvas
    public void BackButton()
    {
        text.text = "";
        back.SetActive(false);
        comb.SetActive(false);
        stains.SetActive(false);
        mud.SetActive(false);
        towel.SetActive(false);
        mirror.SetActive(false);
        canvas.SetActive(false);
        open = false;
    }
}
