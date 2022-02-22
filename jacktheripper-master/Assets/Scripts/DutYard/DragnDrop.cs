using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;


public class DragnDrop : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    List<RaycastResult> results;
    private bool dragging;
    public string name1 = "dummy";
    public string name2 = "dummy";

    public GameObject hints, Option1, Option2, panel, ask, instructions;
    public List<GameObject> hinties;
    public bool o1, o2 = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        dragging = false;
        hinties = new List<GameObject>();
        foreach (Transform t in hints.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.tag == "hint")
            {
                hinties.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
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
            SetPos();
        }
        if (dragging)
        {
            foreach (RaycastResult r in results)
            {
                if (r.gameObject.tag == "hint")
                {
                    r.gameObject.transform.position = Input.mousePosition;
                    break;
                }
            }
        }
    }
    private void SetPos()
    {
        int counter = 0;
        foreach (GameObject hint in hinties)
        {
            if (Option1.GetComponent<BoxCollider2D>().bounds.Contains(hint.transform.position))
            {
                hint.transform.position = Option1.transform.position;
                name1 = hint.GetComponentInChildren<Text>().text;
                o1 = true;
                ask.SetActive(true);
                instructions.SetActive(false);
                counter++;
            }
            if (Option2.GetComponent<BoxCollider2D>().bounds.Contains(hint.transform.position))
            {
                hint.transform.position = Option2.transform.position;
                name2 = hint.GetComponentInChildren<Text>().text;
                o2 = true;
                ask.SetActive(true);
                instructions.SetActive(false);
                counter++;
            }
        }
        if(counter == 0)
        {
            ask.SetActive(false);
            instructions.SetActive(true);
        }
    }
}
