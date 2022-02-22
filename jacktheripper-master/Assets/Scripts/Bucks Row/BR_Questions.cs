using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

//First Question Part of Bucks Row
public class BR_Questions : MonoBehaviour
{
    // Get Gameobjects 
    public Text questionText, ansA, ansB, ansC, ansD;
    // For Score Showing after the Quiz
    public GameObject Instructions;
    // Has Score Script for updating final Score
    public GameObject Canvas;
    // Questions and Answers (drawn from Question Constructor Script)
    public List<Question> questions = new List<Question>();

    // For deactivating afterwards.
    public GameObject Questions;
    int index;

    //Controll waiting time until next answer
    // stopped = in der Coroutine = Warten bis nächste Antwort. !stopped = nächste Frage kann kommen
    bool stopped = false;

    void Start()
    {
        //Add three questions, answers and index of correct answer, given answer
        questions.Add(new Question("Which Object was not found on the scene of crime?",
            "Comb", "Handkerchief", "Mirror", "Cart Tracks", 4, 0));
        questions.Add(new Question("Where did the murder occur?",
            "Whitechapel Road", "Bucks Row", "Bakers Row", "Hanburry Street", 2, 0));
        questions.Add(new Question("Was there a hint to the background of the victim?",
            "Yes, Lambeth Work House", "Yes, Mirror Factory", "Yes, she lived at Bucks Row", "No", 1, 0));

        index = 0;
    }

    void Update()
    {
        //get next answer when coroutine finished
        if (!stopped)
        {
            if (index < questions.Count)
            {
                questionText.text = questions[index].question;
                ansA.text = questions[index].ansA;
                ansB.text = questions[index].ansB;
                ansC.text = questions[index].ansC;
                ansD.text = questions[index].ansD;
            }
            else
            {
                // All questions answered
                StartCoroutine(Example());
                Solve();
                Questions.SetActive(false);
            }
        }
        else
        {
            StartCoroutine(Example());
        }
    }
    
    // Save given answer, mark green when correct.
    public void AddAnswer(int answer)
    {
        if (!stopped)
        {
            questions[index].givenAns = answer;
            string correct = "Ans" + questions[index].rightAns.ToString();
            foreach (Transform t in questionText.GetComponentInChildren<Transform>())
            {
                if (t.gameObject.name == correct)
                {
                    t.gameObject.GetComponentInChildren<Text>().color = new Color(0f, 250f, 0f);
                    stopped = true;
                }
            }
            index += 1;
        }
    }

    //Called when all Answers are given
    void Solve()
    {
        int ans = questions[0].givenAns;
        string ansGiv1 = "";
        //Check which answer was given, per question
        //Q1:
        switch (ans)
        {
            case 1:
                ansGiv1 = "Comb";
                break;
            case 2:
                ansGiv1 = "Handkerchief";
                break;
            case 3:
                ansGiv1 = "Mirror";
                break;
            case 4:
                ansGiv1 = "Cart Tracks";
                break;
        }
        //Q2:
        ans = questions[1].givenAns;
        string ansGiv2 = "";
        switch (ans)
        {
            case 1:
                ansGiv2 = "Whitechapel Road";
                break;
            case 2:
                ansGiv2 = "Bucks Row";
                break;
            case 3:
                ansGiv2 = "Bakers Row";
                break;
            case 4:
                ansGiv2 = "Hanburry Street";
                break;
        }
        //Q3:
        ans = questions[2].givenAns;
        string ansGiv3 = "";
        switch (ans)
        {
            case 1:
                ansGiv3 = "Yes, Lambeth Work House";
                break;
            case 2:
                ansGiv3 = "Yes, Mirror Factory";
                break;
            case 3:
                ansGiv3 = "Yes, she lived at Bucks Row";
                break;
            case 4:
                ansGiv3 = "No";
                break;
        }
        //Count correct answers
        int tmp = 0;
        foreach (Question q in questions)
        {
            if (q.givenAns == q.rightAns)
            {
                tmp += 1;
            }
        }
        //Send score value to Score Script (on MainController Object) to track score
        Canvas.GetComponent<Score>().bRscore_1 = tmp;
        Debug.Log(tmp);
        Canvas.GetComponent<Score>().bRmax_1 = 3;
        //Call Instructions to show player his mistakes/successes
        Instructions.GetComponentInChildren<Text>().text
                    = "The correct anwers are: " +
                    "Which Object was not found on the scene of crime? Cart Tracks. \n" +
                    "Your Answer: " + ansGiv1 + "\n\n" +
                    "Where did the murder occur ? Bucks Row \n" +
                    "Your Answer: " + ansGiv2 + "\n\n" +
                    "Was there a hint to the background of the victim? Yes, Lambeth Work House \n" +
                    "Your Answer: " + ansGiv3 + "\n\n";
        Instructions.SetActive(true);
    }
    
    //Für Coroutine (Wartezeit wie lange die Frage grün angezeigt wird +  alles wieder auf rot setzen)
    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(2);
        ansA.gameObject.GetComponent<Text>().color = new Color(250, 0, 0);
        ansB.gameObject.GetComponent<Text>().color = new Color(250, 0, 0);
        ansC.gameObject.GetComponent<Text>().color = new Color(250, 0, 0);
        ansD.gameObject.GetComponent<Text>().color = new Color(250, 0, 0);
        stopped = false;
    }
}
