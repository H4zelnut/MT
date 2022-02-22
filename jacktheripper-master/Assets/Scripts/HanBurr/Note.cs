using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//Handels Canvas of HBS Investigation AR
public class Note : MonoBehaviour
{
    public Text text;
    public GameObject panelL, panelR, panelM, // Left: Note | right: Name | middle: Picture 
        note, // note on left side
        HBS;
    private List<GameObject> Items;
    private List<string> FoundItems;
    //Touch
    private Touch touch;
    private float tapTime;

    //Letter
    private bool letter;

    void Start()
    {
        Items = new List<GameObject>();
        FoundItems = new List<string>();
        tapTime = 0f;

        letter = true;

        for (int i = 0; i < note.transform.childCount; i++)
        {
            Items.Add(note.transform.GetChild(i).gameObject);
        }
        foreach (GameObject o in Items)
        {
            FoundItems.Add("0");
        }
        Debug.Log("Items: " + Items.Count + " Founds: " + FoundItems.Count);
    }

    //touch input
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
                    if (Input.touchCount<2 )
                    {
                        int temp = 0;
                        hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(touch.position));
                        if (hits != null)
                        {
                            foreach (RaycastHit hit in hits)
                            {
                                temp += 1;
                                if (hit.transform.tag == "Finables2")
                                {
                                    panelL.SetActive(true);
                                    panelR.SetActive(true);
                                    switch (hit.transform.name)
                                    {
                                        case "toothbrush":
                                            Addtext("Toothbrush");
                                            text.text = "A portable Toothbrush. The victim must haver brought it with her.";
                                            break;
                                        case "comb":
                                            Addtext("Comb");
                                            text.text = "A simple comb. Probably belongs to the victim";
                                            break;
                                        case "Letter Front":
                                            if (letter == true)
                                            {
                                                panelM.SetActive(true);
                                                Addtext("Letter");
                                                text.text = "A letter. Has a stamp of sussex regiment on it.";
                                            }
                                            break;
                                        case "blood1":
                                            Addtext("Blood");
                                            text.text = "Blood Stains. There are six of them.";
                                            break;
                                        case "blood2":
                                            Addtext("Blood");
                                            text.text = "Blood Stains. There are six of them.";
                                            break;
                                        case "blood3":
                                            Addtext("Blood");
                                            text.text = "Blood Stains. There are six of them.";
                                            break;
                                        case "blood4":
                                            Addtext("Blood");
                                            text.text = "Blood Stains. There are six of them.";
                                            break;
                                        case "Spritzer":
                                            Addtext("Splashes");
                                            text.text = "Splashes, facing away from where the body lay.";
                                            break;
                                        case "apron":
                                            Addtext("Apron");
                                            text.text = "A leather Apron. Who does it belong to?";
                                            break;
                                    }
                                    Highlight(hit.transform.name);
                                    break;
                                }
                                else if (hit.transform.tag == "CloseAR")
                                {
                                    Back();
                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
    //Adds text to found list if not found already
    void Addtext(string item)
    {
        for (int i = 0; i < FoundItems.Count; i += 1)
        {
            if (FoundItems[i] == item)
            {
                // already in list
                break;
            }
            if (FoundItems[i] == "0")
            {
                FoundItems[i] = item;
                Items[i].GetComponent<Text>().text = item;
                Items[i].SetActive(true);
                break;
            }
        }
    }

    //Closing panel
    public void Back()
    {
        panelL.SetActive(false);
        panelR.SetActive(false);
        panelM.SetActive(false);
    }
    //Highlights current open text
    void Highlight(string current)
    {
        for (int i = 0; i<FoundItems.Count; i++)
        {
            if (FoundItems[i] == current)
            {
                Items[i].GetComponent<Text>().fontStyle = FontStyle.Bold;
            }
            else
            {
                Items[i].GetComponent<Text>().fontStyle = FontStyle.Normal;
            }
        }
    }
}

