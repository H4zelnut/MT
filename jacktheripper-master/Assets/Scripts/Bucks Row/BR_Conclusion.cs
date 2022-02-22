using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Struct with possible Answer and index > for checking if correct answers were chosen later
struct Answer
{
    public string text;
    public int id;
    public Answer(string v1, int v2)
    {
        text = v1;
        id = v2;
    }
}
// Sets the Answers for Bucks Row Conclusion Level
public class BR_Conclusion : MonoBehaviour
{
    private List<GameObject> indizes;
    private List<GameObject> categories;
    
    //List of possible Answers for Field 2 and 3s
    private List<Answer> texts2;
    private List<Answer> texts3;

    //Helper, for easier programming
    private GameObject parent, parentParent;
    
    void Start()
    {
        indizes = new List<GameObject>();
        categories = new List<GameObject>();
        //Indiz
        parent = transform.parent.gameObject;
        //category
        parentParent = parent.transform.parent.gameObject;
        foreach (Transform child in parentParent.transform.parent.gameObject.GetComponentsInChildren<Transform>())
        {
            // Get all indices
            if (child.gameObject.name.Contains("Indiz"))
            {
                indizes.Add(child.gameObject);
            }
            // get all categories
            if (child.gameObject.name.Contains("Category"))
            {
                categories.Add(child.gameObject);
            }
        }

        texts2 = new List<Answer>();
        texts3 = new List<Answer>();

        SetTexts();

        if (parentParent == categories[1])
        {
            GetComponent<Text>().text = texts2[0].text;
        }
        else if (parentParent == categories[2])
        {
            GetComponent<Text>().text = texts3[0].text;
        }
    }
    //switch to next Answer
    public void SwitchImageRight()
    {
        // if Category 2
        if (parentParent == categories[1])
        {
            GetComponent<Text>().text = texts2[1].text;
            string tmp = texts2[0].text;
            int tmpId = texts2[0].id;
            texts2.RemoveAt(0);
            texts2.Add(new Answer(tmp, tmpId));
        }
        // if Category 3
        if (parentParent == categories[2])
        {
            GetComponent<Text>().text = texts3[1].text;
            string tmp = texts3[0].text;
            int tmpId = texts3[0].id;
            texts3.RemoveAt(0);
            texts3.Add(new Answer(tmp, tmpId));
        }
    }
    //switch to prev Answer
    public void SwitchImageLeft()
    {
        //if Category 2
        if (parentParent == categories[1])
        {
            texts2.Insert(0, texts2[texts2.Count - 1]);
            GetComponent<Text>().text = texts2[texts2.Count - 1].text;
            texts2.RemoveAt(texts2.Count - 1);
        }
        //if Category 3
        if (parentParent == categories[2])
        {
            texts3.Insert(0, texts3[texts3.Count - 1]);
            GetComponent<Text>().text = texts3[texts3.Count - 1].text;
            texts3.RemoveAt(texts3.Count - 1);
        }
    }
    //Strings for all possible answers
    private void SetTexts()
    {
        texts2.Add(new Answer("Not enough blood on crime scene", 0));
        texts2.Add(new Answer("Doctor takes his information from newspaper", 1));
        texts2.Add(new Answer("The mirror broke during a fight", 2));
        texts2.Add(new Answer("She combed her hair before she died", 3));
        texts2.Add(new Answer("Traceless mud suggests no carts to carry body", 4));
        texts2.Add(new Answer("Clothes absorbed blood", 5));
        texts2.Add(new Answer("She worked at Lamberth Workhouse", 6));

        texts3.Add(new Answer("She died at Bucks Row", 0));
        texts3.Add(new Answer("She did not die at Bucks Row", 1));
    }
    // If User is ready (pressed send) > Call Solution Method
    public void Send()
    {
        if (parentParent == categories[1])
        {
            parentParent.transform.parent.GetComponent<BR_Conclusion_Lines>().GetSolution(texts2[0].id);
        }
        if (parentParent == categories[2])
        {
            parentParent.transform.parent.GetComponent<BR_Conclusion_Lines>().GetSolution(texts3[0].id);
        }
    }
}
