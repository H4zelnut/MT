using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// Map Puzzle in Dutfields Yard & Twilight Princess 
public class Puzzle : MonoBehaviour
{
    public GameObject piecesParent;
    public GameObject slotsParent;
    private List<GameObject> pieces; //puzzle pieces Gameobjects
    private List<GameObject> slots;  //puzzle pieces positions
    private List<Sprite> pictures;
    private List<Sprite> solution;
    //puzzle pieces
    public Sprite
        i11, i12, i13, i14,
        i21, i22, i23, i24,
        i31, i32, i33, i34,
        i41, i42, i43, i44;
   // private Random rng = new Random();
    private bool solved;

    //Animation
    public GameObject nextPanel;
    public GameObject puzzle;

    // Drag n Drop
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    List<RaycastResult> results;
    private bool dragging;

    
    void Start()
    {
        pieces = new List<GameObject>();
        foreach (RectTransform t in piecesParent.GetComponentsInChildren<RectTransform>())
        {
            pieces.Add(t.gameObject);
        }
        pictures = new List<Sprite>();
        #region pictures.Add(...)
        pictures.Add(i11);
        pictures.Add(i12);
        pictures.Add(i13);
        pictures.Add(i14);
        pictures.Add(i21);
        pictures.Add(i22);
        pictures.Add(i23);
        pictures.Add(i24);
        pictures.Add(i31);
        pictures.Add(i32);
        pictures.Add(i33);
        pictures.Add(i34);
        pictures.Add(i41);
        pictures.Add(i42);
        pictures.Add(i43);
        pictures.Add(i44);
        #endregion
        solution = new List<Sprite>();
        #region solution.Add(...)
        solution.Add(i11);
        solution.Add(i12);
        solution.Add(i13);
        solution.Add(i14);
        solution.Add(i21);
        solution.Add(i22);
        solution.Add(i23);
        solution.Add(i24);
        solution.Add(i31);
        solution.Add(i32);
        solution.Add(i33);
        solution.Add(i34);
        solution.Add(i41);
        solution.Add(i42);
        solution.Add(i43);
        solution.Add(i44);
        #endregion
        
        Shuffle(pictures);
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].GetComponent<Image>().sprite = pictures[i];
        }
        slots = new List<GameObject>();
        foreach (RectTransform t in slotsParent.GetComponentsInChildren<RectTransform>())
        {
            slots.Add(t.gameObject);
        }
        slots.RemoveAt(0);
        solved = false;
        //Dragging
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
        dragging = false;
    }

    void Update()
    {
        if (solved == false)
        {
            #region DragNDrop
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
                SetPosition();
            }
            if (dragging)
            {
                foreach (RaycastResult r in results)
                {
                    if (r.gameObject.tag == "PuzzlePiece")
                    {
                        r.gameObject.transform.position = Input.mousePosition;
                        break;
                    }
                }
            }
            #endregion
            Check();
        }
        else
        {
            nextPanel.SetActive(true);
            puzzle.SetActive(false);
        }
    }
    //Check if puzzle complete > all slots used AND correctly set
    private void Check()
    {
        List<GameObject> solve = new List<GameObject>();
        int tmp = 0;
        foreach (GameObject slot in slots)
        {
            if (pieces.Exists(a => a.transform.position == slot.transform.position))
            {
                tmp += 1;
                solve.Add(pieces.Find(a => a.transform.position == slot.transform.position));
            }
        }
        if (tmp == solution.Count)
        {
            solved = true;
            for (int i = 0; i < solution.Count; i++)
            {
                if (solution[i] != solve[i].GetComponent<Image>().sprite)
                {
                    solved = false;
                    break;
                }
            }
        }
        //Change parent if set into slot
        foreach (GameObject piece in pieces)
        {
            piece.transform.SetParent(slotsParent.transform);
        }
    }
    
    //Handels position
    //If obj collider has slot position in it > set position
    //Called when mouse button up
    private void SetPosition()
    {
        foreach (GameObject obj in pieces)
        {
            foreach (GameObject slot in slots)
            {
                if (obj.GetComponent<BoxCollider2D>().bounds.Contains(slot.transform.position))
                {
                    obj.transform.position = slot.transform.position;
                }
            }
        }
    }

    //Shuffles the sprite list so puzzle pieces start at random positions
    //No one cares ._.
    private void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite tmp = list[i];
            int rndIdx = Random.Range(i, list.Count);
            list[i] = list[rndIdx];
            list[rndIdx] = tmp;
        }
    }
}
