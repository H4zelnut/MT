using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ARRooms : MonoBehaviour
{
    public GameObject one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, twosix, twoseven;
    public GameObject solve;
    List<GameObject> texts;
    List<string> hints;
    public GameObject namePanel;
    string chosenRoom; // chosen resident
    int room; // chosen room
    string[] correct;
    Ray ray;
    RaycastHit hit;
    Touch touch;

    private TextMeshPro text;
    List<string> solution;

    // Start is called before the first frame update
    void Start()
    {
        hints = new List<string>();
        Sethints();

        room = 0;
        correct = new string[15];
        SetCorrect();

        texts = new List<GameObject>();
        texts.Add(one);
        texts.Add(two);
        texts.Add(three);
        texts.Add(four);
        texts.Add(five);
        texts.Add(six);
        texts.Add(seven);
        texts.Add(eight);
        texts.Add(nine);
        texts.Add(ten);
        texts.Add(eleven);
        texts.Add(twelve);
        texts.Add(thirteen);
        texts.Add(twosix);
        texts.Add(twoseven);

        solution = new List<string>();
        SetSolution();
    }

    void SetSolution()
    {
        solution.Add("Julia Venturay");
        solution.Add("Mrs. Keyler");
        solution.Add("Male Market Porter");
        solution.Add("Unknown");
        solution.Add("Mary Ann Cox");
        solution.Add("Unknown");
        solution.Add("John Clark");
        solution.Add("Elizabeth Bushman");
        solution.Add("Unknown");
        solution.Add("Unknown");
        solution.Add("Unknown");
        solution.Add("The Pickets");
        solution.Add("Mary Kelly");
        solution.Add("Storage");
        solution.Add("McCarthy");
    }

    void Sethints()
    {
        hints.Add("No 26 of Dorset Street is used as a Storage room and is next to the victims room."); //
        hints.Add("No 27 of Dorset Street is next to Julia Venturnays room."); //

        hints.Add("Miller's Court resident John Clark, lives under Miller's Court Elizabeth Bushman resident"); //
        hints.Add("Elizabeth Bushman lives in a corner room of Miller's Court building."); //
        hints.Add("The Residents of No 4, 6, 9, 10 and 11 of Miller's Court are unknown."); //
        hints.Add("No 1 and 2 of Miller's Court residents are female."); //

        hints.Add("The couple Catherine and Dave Picket only have one neighbor and live on the upper floor."); //
        hints.Add("Mary Ann Cox lives under an unknown person, in a corner room."); //
        hints.Add("The resident in No 3 of Miller's Court is a male market porter. No name is known."); //
        hints.Add("The victims name is Mary Kelly."); //

        hints.Add("In No 12, the only couple resides"); //

        hints.Add("Mr. McCarthys shop is in Dorset Street"); //
        hints.Add("The resident of No 3 has two female neighbors on the same floor"); //
        hints.Add("One residents name is Mrs.Keyler"); //
    }
    void SetCorrect()
    {
        correct[0] = "Julia Venturnay";
        correct[1] = "Mrs. Keyler";
        correct[2] = "Male Market Porter";
        correct[3] = "Unknown";
        correct[4] = "Mary Ann Cox";
        correct[5] = "Unknown";
        correct[6] = "John Clark";
        correct[7] = "Elizabeth Bushman";
        correct[8] = "Unknown";
        correct[9] = "Unknown";
        correct[10] = "Unknown";
        correct[11] = "The Pickets";
        correct[12] = "Mary Kelly";
        correct[13] = "Storage";
        correct[14] = "McCarthy";
    }
    private void OpenNames()
    {
        namePanel.SetActive(true);
    }
    public void CloseNames()
    {
        namePanel.SetActive(false);
    }
    public void ChooseNames()
    {
        chosenRoom = EventSystem.current.currentSelectedGameObject.name;
        if (room == 26)
        {
            text = texts[13].GetComponentInChildren<TextMeshPro>();
            text.text = chosenRoom;
        }
        else if (room == 27)
        {
            text = texts[14].GetComponentInChildren<TextMeshPro>();
            text.text = chosenRoom;
        }
        else
        {
            texts[room-1].GetComponentInChildren<TextMeshPro>().text = chosenRoom;
        }
        foreach (string s in solution)
        {
            if (s == "")
            {
                solve.SetActive(false);
                break;
            }
            solve.SetActive(true);
        }
        CloseNames();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(touch.position));
            if (hits != null)
            {
                foreach (RaycastHit hit in hits)
                {
                    if (touch.phase == TouchPhase.Ended && hit.collider.tag == "Names")
                    {
                        string tmp = hit.collider.gameObject.name;
                        room = Convert.ToInt32(tmp);
                        OpenNames();
                    }
                    else if(touch.phase == TouchPhase.Ended && hit.collider.tag == "Trigger")
                    {
                        chosenRoom = hit.collider.gameObject.name;
                        ChooseNames();
                    }
                }
            }
        }
    }

    public void Solved()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            if(texts[i].GetComponentInChildren<TextMeshPro>().text.Equals(solution[i]))
            {
                texts[i].GetComponentInChildren<TextMeshPro>().color = Color.green;
            }
            else
            {
                texts[i].GetComponentInChildren<TextMeshPro>().text = solution[i];
                texts[i].GetComponentInChildren<TextMeshPro>().color = Color.red;
            }
        }
    }
}
