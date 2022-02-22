using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

// Dutfields Yard Quiz
// Construct sentences by dragging words into slots
public class DY_Quiz : MonoBehaviour
{
    public GameObject 
        WordField,      // Gameobject with all word snippets
        WordSlots,      // Gameobject with all word slots for answer
        Next, Canvas,   // Score
        Proceed;        // Next Question
    public Text questionField; //Textfield for Question
    private List<GameObject> wordsObj, slotsObj; // fill in all object under WordField/WordSlots
    List<string> questions; 
    List<string> words, words2; 

    //Solution
    public GameObject PanelObj;
    public Text text;
    string answer;
    public int correctAnswersGiven;
    int tmpAnswer;
    public string correct;
    List<string> answers;

    //Solution
    List<string> solution = new List<string>();

    //Shuffle words
    static System.Random rnd = new System.Random();

    //input
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    List<RaycastResult> results;
    private bool dragging;

    void Start()
    {
        Next.SetActive(false);
        wordsObj = new List<GameObject>();
        foreach (Transform t in WordField.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.name == "Word")
            {
                wordsObj.Add(t.gameObject);
            }
        }
        slotsObj = new List<GameObject>();
        foreach (Transform t in WordSlots.GetComponentsInChildren<Transform>())
        {
            slotsObj.Add(t.gameObject);
        }
        slotsObj.RemoveAt(0);

        //Solution
        answers = new List<string>();
        correctAnswersGiven = tmpAnswer = 0;

        //Fragen
        questions = new List<string>();
        FillAnswers();
        questionField.text = questions[0];
        questions.RemoveAt(0);

        FillWords();

        //shuffle
        foreach (GameObject obj in wordsObj)
        {
            int r = rnd.Next(words2.Count);
            obj.GetComponentInChildren<Text>().text = words2[r];
            words2.RemoveAt(r);
        }

        //dragging
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

    }
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
            foreach (RaycastResult r in results)
            {
                foreach (GameObject s in slotsObj)
                {
                    if (r.gameObject.tag == "WORD" && r.gameObject.GetComponent<BoxCollider2D>().bounds.Contains(s.transform.position))
                    {
                        r.gameObject.transform.position = s.transform.position;
                    }
                }
            }
        }
        if (dragging)
        {
            foreach (RaycastResult r in results)
            {
                if (r.gameObject.tag == "WORD")
                {
                    r.gameObject.transform.position = Input.mousePosition;
                    break;
                }
            }
        }
    }

    //Get Next question
    public void NextQuestion()
    {
        if (PanelObj.activeSelf == false)
        {
            PanelObj.SetActive(true);
            answer = "";
            correct = "";
            foreach (GameObject s in slotsObj)
            {
                foreach (GameObject w in wordsObj)
                {
                    if (s.transform.position == w.transform.position)
                    {
                        if (answer != "") { answer += " "; }
                        answer += w.GetComponentInChildren<Text>().text;
                    }
                }
            }
            if (questions.Count != 0)
            {
                questionField.text = questions[0];
                if (Check(questions.Count) == true)
                {
                    PanelObj.GetComponentInChildren<Text>().color = Color.green;
                    tmpAnswer = 1;
                    correctAnswersGiven += 1;
                }
                else
                {
                    PanelObj.GetComponentInChildren<Text>().color = Color.red;
                    tmpAnswer = 0;
                }
                questions.RemoveAt(0);
            }
            else
            {
                WordField.SetActive(false);
                Canvas.GetComponent<Score>().dMScore_1 = correctAnswersGiven;
                Canvas.GetComponent<Score>().dMmax_1 = answers.Count;
                Next.SetActive(true);
                Proceed.SetActive(false);
            }
            answer += " | ";
            answer += tmpAnswer.ToString();
            answers.Add(answer);
            text.text = correct;
        }
        else // panel == true
        {
            PanelObj.SetActive(false);
        }
    }
    //Put Words into list
    //Copy into Words2 for shuffeling
    void FillWords()
    {
        words = new List<string>() { "HE", "SHE", "IT", "THEY", "WAS", "NOT", "SEEN", "IS", "THERE", "WERE", "RIOTS", "REFORMATIONS", "THE", "POLICE", "LETTER", "TOLD", "TRUTH", "IN",
        "KIDNEY", "HEART", "LUNG", "SAUCY JACK", "DEAR BOSS", "ENOUGH", "TIME", "00AM", "AT", "30AM", "45AM", "55AM", "1:", "0:", "2:"};
        words2 = new List<string>();
        words2 = words;
    }
    
    //Check which question is asked and what was answered 
    //returns bool:
    // true > explanation text becomes green
    // false > explanation text becomes red
    //Also Checks for different answers that mean the same
    bool Check(int idx)
    {
        switch (idx)
        {
            case 16:
                correct = "SHE WAS NOT";
                if (answer == "SHE WAS NOT")
                {
                    return true;
                }
                break;
            case 15:
                correct = "AT 0: 55AM";
                if (answer == "AT 0: 55AM" || answer == "0: 55AM")
                {
                    return true;
                }
                break;
            case 14:
                correct = "AT 1: 00AM";
                if (answer == "AT 1: 00AM" || answer == "1: 00AM")
                {
                    return true;
                }
                break;
            case 13:
                correct = "HE WAS SEEN";
                if (answer == "HE WAS" || answer == "HE WAS SEEN")
                {
                    return true;
                }
                break;
            case 12:
                correct = "AT 1: 30AM";
                if (answer == "AT 1: 30AM" || answer == "1: 30AM")
                {
                    return true;
                }
                break;
            case 11:
                correct = "AT 1: 45AM";
                if (answer == "AT 1: 45AM" || answer == "1: 45AM")
                {
                    return true;
                }
                correct = "AT 1: 45AM";
                break;
            case 10:
                correct = "SHE WAS";
                if (answer == "SHE WAS")
                {
                    return true;
                }
                break;
            case 9:
                correct = "HE WAS SEEN";
                if (answer == "HE WAS" || answer == "HE WAS SEEN")
                {
                    return true;
                }
                break;
            case 8:
                correct = "THERE IS";
                if (answer == "THERE IS")
                {
                    return true;
                }
                break;
            case 7:
                correct = "THERE WERE RIOTS";
                if (answer == "THERE WERE RIOTS")
                {
                    return true;
                }
                break;
            case 6:
                correct = "THE POLICE";
                if (answer == "THE POLICE" || answer == "POLICE")
                {
                    return true;
                }
                break;
            case 5:
                correct = "IT WAS NOT";
                if (answer == "IT WAS NOT" || answer == "HE WAS NOT" || answer == "SHE WAS NOT")
                {
                    return true;
                }
                break;
            case 4:
                correct = "THEY TOLD THE TRUTH";
                if (answer == "THEY TOLD THE TRUTH" || answer == "THE LETTER TOLD THE TRUTH" || answer == "THE TRUTH" || answer == "TRUTH")
                {
                    return true;
                }
                break;
            case 3:
                correct = "A KIDNEY";
                if (answer == "A KIDNEY" || answer == "KIDNEY")
                {
                    return true;
                }
                break;
            case 2:
                correct = "IN THE SAUCY JACK LETTER";
                if (answer == "IN THE SAUCY JACK LETTER" || answer == "IN SAUCY JACK LETTER" || answer == "SAUCY JACK LETTER" || answer == "SAUCY JACK")
                {
                    return true;
                }
                break;
            case 1:
                correct = "THERE WAS NOT ENOUGH TIME";
                if (answer == "THERE WAS NOT ENOUGH TIME" || answer == "IT WAS NOT ENOUGH TIME" || answer == "NOT ENOUGH TIME")
                {
                    return true;
                }
                break;
            case 0:
                break;
        }
        return false;
    }

    //Hardcoded Questions into questionlist
    //Answer is in comments
    void FillAnswers()
    {
        questions.Add("Was Elizabeth Stride heavily mutilated?");   // She was not
        questions.Add("When was Elizabeth Stride killed?"); // 0:55 AM
        questions.Add("When was Elizabeth Strides body found?"); //  1 AM
        questions.Add("Was the murderer of Elizabeth Stride seen?"); // He was seen

        questions.Add("When was Catherine Eddowes killed?"); // 1:30
        questions.Add("When was Catherine Eddowes body found?"); //1:45
        questions.Add("Was Catherine Eddowes heavily mutilated?"); // She was
        questions.Add("Was the murderer of Catherine Eddowes seen?"); // He was seen

        questions.Add("Is there a hint to the relgion of the murderer?"); // There is
        questions.Add("Why was the Grafitto erased?"); // There were Riots  // Riots
        questions.Add("Who erased the Grafitto?"); // The Police // police
        questions.Add("Was this decision unanimous?"); // It was not

        questions.Add("Multiple fake letters were received by the police regarding Jack the Ripper. What makes the seen ones genuine?");  // They told the truth
        questions.Add("What internal organ was send with the from hell letter?"); // A kidney
        questions.Add("In which of the letters did the murderer mention, that he killed two people?");  // In the Saucy Jack letter
        questions.Add("Catherine Eddowes ear was partly missing, as announced in the Dear boss Letter. Why didn't he chose Stirdes ear?"); // There was not enough time

        questions.Add("Is the police on the trail of Jack the Ripper?"); // No answer ;)

    }
 }
