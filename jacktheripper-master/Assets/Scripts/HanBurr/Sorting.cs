using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;


//Sorting Clues into categories HBS_Sorting
public class Sorting : MonoBehaviour
{
    public GameObject Norms, Meds, Indis; // categories
    public GameObject next, solve; // UI
    public GameObject canvas; // for Scores
    private List<GameObject> evidence; // clues
    private int index;

    bool solved = false; //checks if solved already

    //Input 
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    List<RaycastResult> results;
    private bool dragging;

    void Start()
    {
        next.SetActive(false); // no skip
        solve.SetActive(false); 
        dragging = false;
        evidence = new List<GameObject>();
        index = 0;
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.tag == "Evidence")
            {
                evidence.Add(t.gameObject);
            }
        }
    }

    // Handels Input and checks if all hints are sorted into one category
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            Check();
        }
        if (dragging)
        {
            foreach (RaycastResult r in results)
            {
                if (r.gameObject.tag == "Evidence")
                {
                    r.gameObject.transform.position = Input.mousePosition;
                    break;
                }

            }
        }
    }
    
    //Check if all objects are categorized already
    //if so > give solve option
    void Check()
    {
        foreach (GameObject obj in evidence)
        {
            // foreach obj in Panel > index+1
            if (Norms.GetComponent<BoxCollider2D>().bounds.Contains(obj.transform.position) ||
                Meds.GetComponent<BoxCollider2D>().bounds.Contains(obj.transform.position) ||
                Indis.GetComponent<BoxCollider2D>().bounds.Contains(obj.transform.position))
            {
                index += 1;
            }
        }
        if (index == evidence.Count && solved == false)
        {
            solve.SetActive(true);
        }
        else
        {
            solve.SetActive(false);
            index = 0;
        }
    }
    
    // Check Users Choice
    // if not correct, hint dissapears from Screen
    // if correct, evidence Child(0) appears (yes hook)
    public void Solve()
    {
        int tmp = 0; // tracks score
        for (int i = 0; i < evidence.Count; i++)
        {
            //evidence no 2 and 5 are Common objects
            if ((i == 2 || i == 5))
            {
                if (Norms.GetComponent<BoxCollider2D>().bounds.Contains(evidence[i].transform.position))
                {
                    evidence[i].transform.GetChild(0).gameObject.SetActive(true);
                    tmp++;
                }
                else
                {
                    evidence[i].gameObject.SetActive(false);
                }
            }
            //evidence no 0 and 4 are Possible clues
            else if ((i == 0 || i == 4))
            {
                if (Indis.GetComponent<BoxCollider2D>().bounds.Contains(evidence[i].transform.position))
                {
                    evidence[i].transform.GetChild(0).gameObject.SetActive(true);
                    tmp++;
                }
                else
                {
                    evidence[i].gameObject.SetActive(false);
                }
            }
            //evidence no 1 and 3 are Biological products
            else
            {
                if (Meds.GetComponent<BoxCollider2D>().bounds.Contains(evidence[i].transform.position))
                {
                    evidence[i].transform.GetChild(0).gameObject.SetActive(true);
                    tmp++;
                }
                else
                {
                    evidence[i].gameObject.SetActive(false);
                }
            }
        }
        // update score
        canvas.GetComponent<Score>().hBSscore_1 = tmp;
        canvas.GetComponent<Score>().hBSmax_1 = 6;
        // let player progress
        next.SetActive(true);
        solve.SetActive(false);
        solved = true;
    }
}
