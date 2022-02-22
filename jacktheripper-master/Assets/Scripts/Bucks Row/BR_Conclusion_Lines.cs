using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class BR_Conclusion_Lines : MonoBehaviour
{
    private List<GameObject> indizes;
    public GameObject parent;
    public GameObject Canvas, next;
    private List<GameObject> line;

    // For Evaluation
    private List<int> solution;

    void Start()
    {
        indizes = new List<GameObject>();
        line    = new List<GameObject>();
        solution = new List<int>();
        next.SetActive(false);
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.name.Contains("Indiz"))
            {
                indizes.Add(child.gameObject);
            }
        }
    }
    // Called from BR_Conclusion Script
    public void GetSolution(int i)
    {
        solution.Add(i);
        if(solution.Count == 4)
        {
            next.SetActive(true);
            CompareSolution();
        }
    }
    //Called when all fields are chosen. Checks for correct solution. Colors correct answers in green. 
    void CompareSolution()
    {
        // tmp counter for score tracking.
        int tmp = 0;
        
        if(solution[0] == 0)
        {
            indizes[3].GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp++;
        }
        if(solution[1] == 5)
        {
            indizes[4].GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp++;
        }
        if(solution[2] == 4)
        {
            indizes[5].GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp++;
        }
        if(solution[3] == 0)
        {
            indizes[6].GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
            tmp++;
        }
        //Send score value to Score Script (on MainController Object) to track score.
        Canvas.GetComponent<Score>().bRscore_3 = tmp;
        Canvas.GetComponent<Score>().bRmax_3 = 4;
    }
}
