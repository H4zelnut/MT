using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// HBS Relations Quiz
public class HBS_Relations : MonoBehaviour
{
    private bool step,
        davies, donovan, richardson, smith, kent, green, phillips, chandler, pizer; //chosen person
    public GameObject 
        question,   //Question in the middle
        next,       //Skip day
        canvas,     //Score.cs Object
        solve,      //Check if choice is correct
        DaviesObj, DonovanObj, RichardsonObj, SmithObj, KentObj, GreenObj, PhillipsObj, ChandlerObj, PizerObj; // clickable persons
    private List<string> questions;
    int index; // current question
    int score;

    // Start is called before the first frame update
    void Start()
    {
        next.SetActive(false);
        questions = new List<string>();
        davies = donovan = richardson = smith = kent = green = phillips = chandler = pizer = false;
        step = true; // if true, > show answer to question
        FillQuestions();
        index = score = 0; // index = current question 
        question.GetComponent<Text>().text = questions[0];
    }
    //Called per Check()
    //Sets true answers green, wrong ones red and chosen, but not correct ones yellow
    public void Solve()
    {
        if (!step)
        {
            // reset all to red
            DaviesObj.GetComponentInChildren<Text>().color = Color.red;
            DonovanObj.GetComponentInChildren<Text>().color = Color.red;
            RichardsonObj.GetComponentInChildren<Text>().color = Color.red;
            SmithObj.GetComponentInChildren<Text>().color = Color.red;
            KentObj.GetComponentInChildren<Text>().color = Color.red;
            GreenObj.GetComponentInChildren<Text>().color = Color.red;
            PhillipsObj.GetComponentInChildren<Text>().color = Color.red;
            ChandlerObj.GetComponentInChildren<Text>().color = Color.red;
            PizerObj.GetComponentInChildren<Text>().color = Color.red;
            step = true;

            // last solve
            if(index == 10)
            {
                next.SetActive(true);
                solve.SetActive(false);

                canvas.GetComponent<Score>().hBSscore_2 = score;
                canvas.GetComponent<Score>().hBSmax_2 = 10;
            }
            else
            {
                solve.GetComponentInChildren<Text>().text = "Check";
                question.GetComponent<Text>().text = questions[index];
                davies = donovan = richardson = smith = kent = green = phillips = chandler = pizer = false;
            }
        }
        else
        {
            switch (index)
            {
                case 0:
                    if (!davies && !donovan && !richardson && !smith && !kent && !green && !phillips && chandler && !pizer)
                    {
                        score++;
                    }
                    ChandlerObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 1:
                    if (!davies && !donovan && !richardson && !smith && !kent && !green && phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    PhillipsObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 2:
                    if (davies && !donovan && !richardson && !smith && !kent && !green && !phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    DaviesObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 3:
                    if(!davies && !donovan && !richardson && !smith && !kent && !green && phillips && chandler && !pizer)
                    {
                        score++;
                    }
                    ChandlerObj.GetComponentInChildren<Text>().color = Color.green;
                    PhillipsObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 4:
                    if (!davies && !donovan && !richardson && !smith && !kent && !green && !phillips && !chandler && pizer)
                    {
                        score++;
                    }
                    PizerObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 5:
                    if (!davies && !donovan && richardson && !smith && !kent && !green && !phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    RichardsonObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 6:
                    if (!davies && !donovan && !richardson && smith && !kent && !green && !phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    SmithObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 7:
                    if (!davies && !donovan && richardson && !smith && !kent && !green && !phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    RichardsonObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 8:
                    if(!davies && donovan && !richardson && smith && !kent && !green && !phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    DonovanObj.GetComponentInChildren<Text>().color = Color.green;
                    SmithObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
                case 9:
                    if(!davies && !donovan && richardson && !smith && kent && green && !phillips && !chandler && !pizer)
                    {
                        score++;
                    }
                    GreenObj.GetComponentInChildren<Text>().color = Color.green;
                    KentObj.GetComponentInChildren<Text>().color = Color.green;
                    RichardsonObj.GetComponentInChildren<Text>().color = Color.green;
                    break;
            }
            step = false;
            index++;
            solve.GetComponentInChildren<Text>().text = "Next";
        }
    }
    
    // Hardcode Questions
    // Answers in comments
    void FillQuestions()
    {
        questions.Add("Who was the inspector of the case?"); //chandler
        questions.Add("Who was the doctor who examined the victim?"); //phillips
        questions.Add("Who discovered the body?"); // davies
        questions.Add("Who works for the police?"); // chandler phillips
        questions.Add("Who was a supsect?"); // pizer
        questions.Add("Who is a neighbor?"); //richardson
        questions.Add("Who is related to the victim ?"); // smith 
        questions.Add("Who knows the owner of the leather apron?"); // richardson
        questions.Add("Who knew the victim?"); //Donovan //smith
        questions.Add("Who works at Hanburry Street?"); // green kent richardson
    }

    //Handels colors of Persons
    //Called when Clicked on Persons
    public void Davies()
    {
        if (davies)
        {
            davies = false;
            DaviesObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            davies = true;
            DaviesObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Donovan()
    {
        if (donovan)
        {
            donovan = false;
            DonovanObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            donovan = true;
            DonovanObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Richardson()
    {
        if (richardson)
        {
            richardson = false;
            RichardsonObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            richardson = true;
            RichardsonObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Smith()
    {
        if (smith)
        {
            smith = false;
            SmithObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            smith = true;
            SmithObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Kent()
    {
        if (kent)
        {
            kent = false;
            KentObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            kent = true;
            KentObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Green()
    {
        if (green)
        {
            green = false;
            GreenObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            green = true;
            GreenObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Phillips()
    {
        if (phillips)
        {
            phillips = false;
            PhillipsObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            phillips = true;
            PhillipsObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Chandler()
    {
        if (chandler)
        {
            chandler = false;
            ChandlerObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            chandler = true;
            ChandlerObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
    public void Pizer()
    {
        if (pizer)
        {
            pizer = false;
            PizerObj.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            pizer = true;
            PizerObj.GetComponentInChildren<Text>().color = Color.yellow;
        }
    }
}
