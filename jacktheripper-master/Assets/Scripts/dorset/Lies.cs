using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

//Last Quiz of Dorset Street/Millers Court
//Look at Notebook statement summaries from Inquest.cs and check for mistakes/lies/contradiction
public class Lies : MonoBehaviour
{
    public GameObject   NotesLeft,  //Left side Gameobject   
                        NotesRight, //Right side Gameobject. Objects are identical
                        Objection,  //Button that appears whenever two statements are chosen
                        Answer,     //Appears when contradiction is called > shows if true or already found or wrong
                        ScoreObj,   //for updating score
                        Question,   //"Do you see anything wrong with these statements?"
                        Scores;     //Indicator at top left corner of screen to make it easier
    public Sprite red, blue, green; //sprites for highlighting. blue = already found, green = true, red = false

    //List of all Objects of category(for easy looping):
    List<GameObject>    NR, //NR= Notes on Right side (wittness statement summary)
                        NL, //NL= Notes on Left side (wittness statement summary)
                        IR, //IR= Images on Right side (Witness heads)
                        IL; //IR= Images on Left side (Witness heads)
    List<string> abberline, barnett, cox, phillips; //Notes summary for each person.
    List<int> a, b, c, p;   //shows which points contradict eachself. eg: if a[x]=1 and b[y]=1 > a at x contradicts b at y 
                            //total of 3 contradictions: 0> contradicts nothing, 1> first contradiction, 2 > second, 3 > third

    int index,                      // how much objects are currently highlighted. Max 2 can be highlighted > tracking needed
        chosenTextL, chosenTextR,   // Which note is chosen left and right
        mistakes, score;           // counts true contradictions and wrong ones. Already found ones give nothing
        
    
    void Start()
    {
        abberline = new List<string>();
        barnett = new List<string>();
        cox = new List<string>();
        phillips = new List<string>();
        a = new List<int>();
        b = new List<int>();
        c = new List<int>();
        p = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            a.Add(0);
            b.Add(0);
            c.Add(0);
            p.Add(0);
        }
        SetLists();
        IL = new List<GameObject>();
        IR = new List<GameObject>();
        NR = new List<GameObject>();
        NL = new List<GameObject>();
        foreach (Transform obj in NotesLeft.GetComponentInChildren<Transform>())
        {
            if (obj.gameObject.tag == "Note")
            {
                NL.Add(obj.gameObject);
            }
            else if (obj.gameObject.tag == "Pic")
            {
                IL.Add(obj.gameObject);
            }
        }
        foreach (Transform obj in NotesRight.GetComponentInChildren<Transform>())
        {
            if (obj.gameObject.tag == "Note")
            {
                NR.Add(obj.gameObject);
            }
            else if (obj.gameObject.tag == "Pic")
            {
                IR.Add(obj.gameObject);
            }
        }
        for (int i = 0; i < abberline.Count; i++)
        {
            NL[i].GetComponent<Text>().text = abberline[i];
            NR[i].GetComponent<Text>().text = abberline[i];
        }
        mistakes = 0;
        score = 0;
        index = 0;
    }

    //called when statement is chosen
    //checks if there are already 2 chosen, 
    //else de choses statement if it was chosen before
    //else choses statement
    //uses index to track amount of chosen statements
    public void Text()
    {
        GameObject curr = EventSystem.current.currentSelectedGameObject;
        if (NL.Contains(curr))
        {
            if (index < 2 && !curr.transform.GetChild(0).gameObject.activeSelf && curr.transform.GetChild(0).gameObject.tag != "Note")
            {
                curr.transform.GetChild(0).gameObject.SetActive(true);
                index += 1;
            }
            else if (curr.transform.GetChild(0).gameObject.activeSelf && curr.transform.GetChild(0).gameObject.tag != "Note")
            {
                curr.transform.GetChild(0).gameObject.SetActive(false);
                index -= 1;
            }
        }
        else if (NR.Contains(curr))
        {
            if (index < 2 && !curr.transform.GetChild(0).gameObject.activeSelf && curr.transform.GetChild(0).gameObject.tag != "Note")
            {
                curr.transform.GetChild(0).gameObject.SetActive(true);
                index += 1;
            }
            else if (curr.transform.GetChild(0).gameObject.activeSelf && curr.transform.GetChild(0).gameObject.tag != "Note")
            {
                curr.transform.GetChild(0).gameObject.SetActive(false);
                index -= 1;
            }
        }
        if (index == 2)
        {
            Objection.SetActive(true);
        }
        else
        {
            Objection.SetActive(false);
        }
    }

    //called when person is chosen
    //changes statements according to chosen person
    public void Images()
    {
        GameObject curr = EventSystem.current.currentSelectedGameObject;
        if (IL.Contains(curr))
        {
            foreach (GameObject obj in IL)
            {
                obj.transform.GetChild(0).gameObject.SetActive(false);
            }
            curr.transform.GetChild(0).gameObject.SetActive(true);
            if (curr == IL[0])
            {
                for (int i = 0; i < abberline.Count; i++)
                {
                    NL[i].GetComponent<Text>().text = abberline[i];
                }
            }
            else if (curr == IL[1])
            {
                for (int i = 0; i < barnett.Count; i++)
                {
                    NL[i].GetComponent<Text>().text = barnett[i];
                }
            }
            else if (curr == IL[2])
            {
                for (int i = 0; i < cox.Count; i++)
                {
                    NL[i].GetComponent<Text>().text = cox[i];
                }
            }
            else if (curr == IL[3])
            {
                for (int i = 0; i < phillips.Count; i++)
                {
                    NL[i].GetComponent<Text>().text = phillips[i];
                }
            }
        }
        else if (IR.Contains(curr))
        {
            foreach (GameObject obj in IR)
            {
                obj.transform.GetChild(0).gameObject.SetActive(false);
            }
            curr.transform.GetChild(0).gameObject.SetActive(true);
            if (curr == IR[0])
            {
                for (int i = 0; i < abberline.Count; i++)
                {
                    NR[i].GetComponent<Text>().text = abberline[i];
                }
            }
            else if (curr == IR[1])
            {
                for (int i = 0; i < barnett.Count; i++)
                {
                    NR[i].GetComponent<Text>().text = barnett[i];
                }
            }
            else if (curr == IR[2])
            {
                for (int i = 0; i < cox.Count; i++)
                {
                    NR[i].GetComponent<Text>().text = cox[i];
                }
            }
            else if (curr == IR[3])
            {
                for (int i = 0; i < phillips.Count; i++)
                {
                    NR[i].GetComponent<Text>().text = phillips[i];
                }
            }
        }
    }

    //Called when Contradiction was called. Panel shows user if hes correct. This function closes the panel
    //Checks if last contradiction was found > progresses in story
    public void CloseAnswer()
    {
        Debug.Log("score: " + score);
        Debug.Log("mistakes: " + mistakes);
        if (score < 3)
        {
            Answer.SetActive(false);
            NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = blue;
            NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = blue;
        }
        else //(score == 3)
        {
            Question.GetComponent<Text>().text = "And yet, no one was captured as the killer.";
            NotesLeft.SetActive(false);
            NotesRight.SetActive(false);
            int temp = score - mistakes;
            if (temp < 0) { temp = 0; }
            Answer.GetComponentInChildren<Text>().text = "Mary Kellys Inquest was closed after a single day. The Coroner stated the followeing: \"My own opinion is that it is very unnecessary for two courts to deal with these cases, and go through the same evidence time after time, " +
                "which only causes expense and trouble. If the coroner's jury can come to a decision as to the cause of death, then that is all that they have to do. They have nothing to do with " +
                "prosecuting a man and saying what amount of penalty he is to get. It is quite sufficient if they find out what the cause of death was. It is for the police authorities to deal with " +
                "the case and satisfy themselves as to any person who may be suspected later on.\"\n " +
                "Your Score: " + score + "\n" +
                "Your Mistakes: " + mistakes + "\n" +
                "Total: " + temp + ".";
            Scores.GetComponent<Score>().mCScore_3 = temp;
            Scores.GetComponent<Score>().mCMax_3 = 3;
            Objection.SetActive(false);
            Answer.SetActive(false);
        }
    }

    //Called by Button that is visible if two statements are chosen
    //Check which ones are chosen
    //Check if they are a true contradiction > update interface
    //show panel
    public void CallObjection()
    {
        int chosenPersonR = 0;
        int chosenPersonL = 0;
        for (int i = 0; i < IR.Count; i++)
        {
            if (IR[i].transform.GetChild(0).gameObject.activeSelf)
            {
                chosenPersonR = i;
            }
            if (IL[i].transform.GetChild(0).gameObject.activeSelf)
            {
                chosenPersonL = i;
            }
        }
        chosenTextR = 0;
        chosenTextL = 0;
        for (int i = 0; i < NL.Count; i++)
        {
            if (NL[i].transform.GetChild(0).gameObject.activeSelf)
            {
                chosenTextL = i;
            }
            if (NR[i].transform.GetChild(0).gameObject.activeSelf)
            {
                chosenTextR = i;
            }
        }

        //Correct Case 1: Barnett & Phillips 
        if (chosenPersonL == 1 && chosenPersonR == 3)
        {
            if (b[chosenTextL] == 1 && p[chosenTextR] == 1)
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                Answer.GetComponentInChildren<Text>().text = "Barnett admitted that he could only recognize her by the eyes and ears";
                Answer.SetActive(true);
                b[chosenTextL] = 5;
                p[chosenTextR] = 5;
                score += 1;
            }
            else if (b[chosenTextL] == 5 && p[chosenTextR] == 5)
            {
                Answer.GetComponentInChildren<Text>().text = "You already found this Contradiction";
                Answer.SetActive(true);
            }
            else
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
                Answer.SetActive(true);
                mistakes += 1;
            }
        }
        else if (chosenPersonR == 1 && chosenPersonL == 3)
        {
            if (b[chosenTextR] == 1 && p[chosenTextL] == 1)
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                Answer.GetComponentInChildren<Text>().text = "Barnett admitted that he could only recognize her by the eyes and ears";
                Answer.SetActive(true);
                b[chosenTextL] = 5;
                p[chosenTextR] = 5;
                score += 1;
            }
            else if (b[chosenTextR] == 5 && p[chosenTextL] == 5)
            {
                Answer.GetComponentInChildren<Text>().text = "You already found this Contradiction";
                Answer.SetActive(true);
            }
            else
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
                Answer.SetActive(true);
                mistakes += 1;
            }
        }
        //Correct Case 2: Barnett & Cox
        else if (chosenPersonL == 1 && chosenPersonR == 2)
        {
            if (b[chosenTextL] == 2 && c[chosenTextR] == 2)
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                Answer.GetComponentInChildren<Text>().text = "Everyone knew that Mary Kelly were drinking a lot but Barnett still told the police that she was a sober woman";
                Answer.SetActive(true);
                b[chosenTextL] = 5;
                c[chosenTextR] = 5;
                score += 1;
            }
            else if (b[chosenTextL] == 5 && c[chosenTextR] == 5)
            {
                Answer.GetComponentInChildren<Text>().text = "You already found this Contradiction";
                Answer.SetActive(true);
            }
            else
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
                Answer.SetActive(true);
                mistakes += 1;
            }
        }
        else if (chosenPersonR == 1 && chosenPersonL == 2)
        {
            if (b[chosenTextR] == 2 && c[chosenTextL] == 2)
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                Answer.GetComponentInChildren<Text>().text = "Everyone knew that Mary Kelly was drinking a lot but Barnett still told the police that she was a sobar woman";
                Answer.SetActive(true);
                b[chosenTextR] = 5;
                c[chosenTextL] = 5;
                score += 1;
            }
            else if (b[chosenTextR] == 5 && c[chosenTextL] == 5)
            {
                Answer.GetComponentInChildren<Text>().text = "You already found this Contradiction";
                Answer.SetActive(true);
            }
            else
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
                Answer.SetActive(true);
                mistakes += 1;
            }
        }
        //Correct Case 3: Abberline && Phillips
        else if (chosenPersonL == 0 && chosenPersonR == 3)
        {
            if (a[chosenTextL] == 3 && p[chosenTextR] == 3)
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                Answer.GetComponentInChildren<Text>().text = "Caroline Maxwell admitted that she didn't knew the victim well and only recognized her by the clothes";
                Answer.SetActive(true);
                a[chosenTextL] = 5;
                p[chosenTextR] = 5;
                score += 1;
            }
            else if (a[chosenTextL] == 5 && p[chosenTextR] == 5)
            {
                Answer.GetComponentInChildren<Text>().text = "You already found this Contradiction";
                Answer.SetActive(true);
            }
            else
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
                Answer.SetActive(true);
                mistakes += 1;
            }
        }
        else if (chosenPersonR == 0 && chosenPersonL == 3)
        {
            if (a[chosenTextR] == 3 && p[chosenTextL] == 3)
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = green;
                Answer.GetComponentInChildren<Text>().text = "Caroline Maxwell admitted that she didn't knew the victim well and only recognized her by the clothes";
                Answer.SetActive(true);
                a[chosenTextR] = 5;
                p[chosenTextL] = 5;
                score += 1;
            }
            else if (a[chosenTextR] == 5 && p[chosenTextL] == 5)
            {
                Answer.GetComponentInChildren<Text>().text = "You already found this Contradiction";
                Answer.SetActive(true);
            }
            else
            {
                NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
                Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
                Answer.SetActive(true);
                mistakes += 1;
            }

        }
        else
        {
            NL[chosenTextL].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
            NR[chosenTextR].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = red;
            Answer.GetComponentInChildren<Text>().text = "There is no Contradiction here";
            Answer.SetActive(true);
            mistakes += 1;
        }
        ScoreObj.GetComponent<Text>().text = score.ToString() + "/3";
    }

    //hardcoded Notes list
    //sets contradiction values
    void SetLists()
    {
        abberline.Add("Waited until 1:30pm");
        abberline.Add("Clothes in the fireplace");
        abberline.Add("Room was quite dark");
        abberline.Add("Missing Key");
        abberline.Add("Victim was seen at 8:30 AM on 10th November");
        a[4] = 3;

        barnett.Add("Recognized her with no doubt");
        barnett.Add("Seperated because of a woman of bad character");
        barnett.Add("Victim didn't drink much");
        barnett.Add("Leaves her on friendly term");
        barnett.Add("Victim was afraid of the murders");
        b[0] = 1;
        b[2] = 2;

        cox.Add("Mary Jane returned at 11:45 PM");
        cox.Add("Kelly was in Company with a man");
        cox.Add("Kelly sang from 11:45 PM to 3:00 AM");
        cox.Add("Victim wore no hat, red cape, shabby skirt");
        cox.Add("Drinks a lot");
        c[4] = 2;

        phillips.Add("Arrived at 11:15 AM");
        phillips.Add("Checked life signs");
        phillips.Add("Door is broken by McCarthy");
        phillips.Add("Victim was mutilated beyond recognition");
        phillips.Add("Victim died on the right side of the bed at around 3:30 AM");
        p[3] = 1;
        p[4] = 3;
    }
}
