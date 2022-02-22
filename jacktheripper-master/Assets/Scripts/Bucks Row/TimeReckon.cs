using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

//Pairing of Transform (less coding than Gameobject) and bool
//true indicates that Gameobject has been paired
//false indicates that Gameobject has not been paired yet
struct Pair
{
    public Transform transform;
    public bool set;
    public Pair(Transform v1, bool v2)
    {
        transform = v1;
        set = v2;
    }
}

//Quiz: Match time and Action of Bucks Row Murder
public class TimeReckon : MonoBehaviour
{
    public GameObject Time; // parent obj of all time slot positions
    public GameObject Action; // parent obj of all action slot positions
    public GameObject Snippet; // parent of all times and action snippets

    //Skip day (for deactivating until finished)
    public GameObject Next;

    private List<Pair> times; //all time slots
    private List<Pair> actions; // all action slots
    private List<Transform> snippets; // all action/time snippets

    public GameObject Button;
    public GameObject Canvas;
    int counter; // counts how many slots are set;

    // Dragging
    bool dragging; // currently dragging a snippet?
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    //Lines
    List<RaycastResult> results;
    List<GameObject> lines;
    
    // Start is called before the first frame update
    void Start()
    {
        times = new List<Pair>();
        actions = new List<Pair>();
        snippets = new List<Transform>();
        lines = new List<GameObject>();
        // fill time slot/ action slot/ snippet lists
        foreach (Transform t in Time.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.tag == "TimeSlot")
            {
                times.Add(new Pair(t, false));
            }
        }
        foreach (Transform t in Action.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.tag == "ActionSlot")
            {
                actions.Add(new Pair(t, false));
            }
        }
        foreach (Transform t in Snippet.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.tag == "Snippet")
            {
                snippets.Add(t);
            }
        }

        dragging = false;
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

        DrawLine();
        counter = 0;
    }
    

    void Update()
    {
        // Check if line can be activated (Time&action slot filled)
        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].set == true && times[i].set == true)
            {
                lines[i].SetActive(true);
            }
        }

        //Dragging the Snippets 
        //If Time or Action Slot collides with snippet, set snippet pos to slot position
        //> Fill slot positions
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            foreach (Transform s in snippets)
            {
                for (int i = 0; i < times.Count; i++)
                {
                    if (s.gameObject.GetComponent<BoxCollider2D>().bounds.Contains(times[i].transform.position))
                    {
                        s.gameObject.transform.position = times[i].transform.position;
                        Pair tmp = new Pair(times[i].transform, true); // Set bool set auf true > One slot filled
                        times[i] = tmp;
                    }
                    if (s.gameObject.GetComponent<BoxCollider2D>().bounds.Contains(actions[i].transform.position))
                    {
                        s.gameObject.transform.position = actions[i].transform.position;
                        Pair tmp = new Pair(actions[i].transform, true); // Set bool set auf true > One slot filled
                        actions[i] = tmp;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
        }
        if (dragging)
        {
            foreach (RaycastResult r in results)
            {
                foreach (Transform s in snippets)
                {
                    if (r.gameObject.tag == "Snippet")
                    {
                        for (int i = 0; i < times.Count; i++)
                        {
                            if (times[i].transform.position == s.gameObject.transform.position)
                            {
                                times[i] = new Pair(times[i].transform, false);  // if pairing gets seperated > deactivate line
                                lines[i].SetActive(false);
                            }
                            else if (actions[i].transform.position == s.gameObject.transform.position)
                            {
                                actions[i] = new Pair(actions[i].transform, false);  // if pairing gets seperated > deactivate line
                                lines[i].SetActive(false);
                            }
                        }
                    }
                }
                if (r.gameObject.tag == "Snippet")
                {
                    r.gameObject.transform.position = Input.mousePosition;
                    break;
                }
            }
        }

        // Count if all slots are filled yet. If so > activate Finish Button to let player Finish the quiz.
        counter = 0;
        for (int i = 0; i < times.Count; i++)
        {
            if (times[i].set == true) { counter += 1; }
            if (actions[i].set == true) { counter += 1; }
        }
        if (counter == times.Count + actions.Count)
        {
            Button.SetActive(true);
        }
        else
        {
            Button.SetActive(false);
        }
    }
    
    // Initializes Lines between Time Slot and corresponding Action Slot
    // Appears if matching Slots are both set
    // Disappears if matching Slots are not set or only one is set
    void DrawLine()
    {
        for (int i = 0; i < times.Count; i++)
        {
            GameObject line = new GameObject();
            string name = "Line ";
            name += i.ToString();
            line.name = name;
            line.transform.SetParent(transform);
            line.AddComponent<Image>();
            Vector3 middle = (times[i].transform.position + actions[i].transform.position) / 2;
            line.transform.position = middle;
            float width = Vector3.Distance(times[i].transform.position, actions[i].transform.position);
            line.GetComponent<Image>().color = new Color(0f, 0f, 255f);
            Vector2 tmp = new Vector2(width, 2f);
            line.GetComponent<RectTransform>().sizeDelta = tmp;
            lines.Add(line);
            line.transform.SetAsFirstSibling();
            line.SetActive(false);
        }
    }

    // Checks if Set Pairings are correct when User presses Finish
    // tmp variable counts correct answers for score
    public void Solution()
    {
        int tmp = 0;
        #region times
        if (snippets.Find(x => x.transform.position == times[0].transform.position) == snippets[0])
        {
            snippets.Find(x => x.transform.position == times[0].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == times[1].transform.position) == snippets[3])
        {
            snippets.Find(x => x.transform.position == times[1].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == times[2].transform.position) == snippets[6])
        {
            snippets.Find(x => x.transform.position == times[2].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == times[3].transform.position) == snippets[7])
        {
            snippets.Find(x => x.transform.position == times[3].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == times[4].transform.position) == snippets[8])
        {
            snippets.Find(x => x.transform.position == times[4].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        #endregion
        #region actions
        if (snippets.Find(x => x.transform.position == actions[0].transform.position) == snippets[11])
        {
            snippets.Find(x => x.transform.position == actions[0].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == actions[1].transform.position) == snippets[13])
        {
            snippets.Find(x => x.transform.position == actions[1].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == actions[2].transform.position) == snippets[4])
        {
            snippets.Find(x => x.transform.position == actions[2].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == actions[3].transform.position) == snippets[9])
        {
            snippets.Find(x => x.transform.position == actions[3].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        if (snippets.Find(x => x.transform.position == actions[4].transform.position) == snippets[10])
        {
            snippets.Find(x => x.transform.position == actions[4].transform.position).gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp += 1;
        }
        #endregion
        // update score to Score.cs
        Canvas.GetComponent<Score>().bRscore_2 = tmp;
        Canvas.GetComponent<Score>().bRmax_2 = times.Count + actions.Count;
    }
}

