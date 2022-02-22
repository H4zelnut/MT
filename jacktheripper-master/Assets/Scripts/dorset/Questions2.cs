using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.IO;

//Second Question Script
//Questions look like a notebook
public class Questions2 : MonoBehaviour
{
    //Question Object consists of:
    //string quest, answer 1, answer 2, answer3
    //correct answer as int
    struct Question
    {
        public string quest;
        public string ans1, ans2, ans3;
        public int correct;

        public Question(string quest, string ans1, string ans2, string ans3, int correct)
        {
            this.quest = quest;
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.correct = correct;
        }
    }

    public Text question, a1, a2, a3, corrected; //Textfields für Questions Objects
    public GameObject check, done, Scores;
    List<Question> questions; // all Questions

    List<string> corrects;
    int index, score;
    string textAll;

    List<int> solution; //saves the chosen answer number 

    // Start is called before the first frame update
    void Start()
    {
        questions = new List<Question>();
        FillQuestions();
        index = 0;
        score = 0;

        question.text = questions[index].quest;
        a1.text = questions[index].ans1;
        a2.text = questions[index].ans2;
        a3.text = questions[index].ans3;
        solution = new List<int>();
        corrects = new List<string>();

    }

    //Called when clicked on an answer
    //gets chosen string and Adds it to solution
    public void Answer()
    {
        string chosen = "";
        GameObject tmp = EventSystem.current.currentSelectedGameObject;
        chosen = tmp.GetComponent<Text>().text;
        if (tmp.name == "Ans1")
        {
            solution.Add(1);
        }
        else if (tmp.name == "Ans2")
        {
            solution.Add(2);
        }
        else if (tmp.name == "Ans3")
        {
            solution.Add(3);
        }
        index += 1;
        switch (index)
        {
            case 1:
                if (solution[0] == questions[0].correct)
                {
                    textAll += "Scotland Yard used a " + chosen + "technique by using blood hounds. \n";
                    corrected.text += "Scotland Yard used a<color=green> new</color> technique by using blood hounds. \n";
                    score += 1;
                }
                else
                {
                    textAll += "Scotland Yard used a " + chosen + "technique by using blood hounds. \n";
                    corrected.text += "Scotland Yard used a<color=red> new</color> technique by using blood hounds. \n";
                }
                break;
            case 2:
                if (solution[1] == questions[1].correct)
                {
                    textAll += "The Doctor that was called was " + chosen + ". \n";
                    corrected.text += "The Doctor that was called was<color=green> George Baxter Phillips</color>. \n";
                    score += 1;
                }
                else
                {
                    textAll += "The Doctor that was called was " + chosen + ". \n";
                    corrected.text += "The Doctor that was called was<color=red> George Baxter Phillips</color>. \n";
                }
                break;
            case 3:
                if (solution[2] == questions[2].correct)
                {
                    textAll += "They entered the room " + chosen + "\n";
                    corrected.text += "They entered the room<color=green> after they received orders to do so </color>. \n";
                    score += 1;
                }
                else
                {
                    textAll += "They entered the room " + chosen + "\n";
                    corrected.text += "They entered the room<color=red> after they received orders to do so </color>. \n";
                }
                break;
            case 4:
                if (solution[3] == questions[3].correct)
                {
                    textAll += "Regarding the hounds, Scotland Yard " + chosen + ". \n";
                    corrected.text += "Regarding the hounds, Scotland Yard<color=green> did not pay the owner</color>. \n";
                    score += 1;
                }
                else
                {
                    textAll += "Regarding the hounds, Scotland Yard " + chosen + ". \n";
                    corrected.text += "Regarding the hounds, Scotland Yard<color=red> did not pay the owner</color>. \n";
                }
                break;
            case 5:
                if (solution[4] == questions[4].correct)
                {
                    textAll += "The door was eventually " + chosen + ". \n";
                    corrected.text += "The door was eventually<color=green> choped down by the rooms owner </color>. \n";
                    score += 1;
                }
                else
                {
                    textAll += "The door was eventually " + chosen + ". \n";
                    corrected.text += "The door was eventually<color=red> choped down by the rooms owner </color>. \n";
                }
                a1.gameObject.SetActive(false);
                a2.gameObject.SetActive(false);
                a3.gameObject.SetActive(false);
                check.SetActive(true);
                break;
        }
        if (index < 6)
        {
            question.text = textAll + questions[index].quest;
            a1.text = questions[index].ans1;
            a2.text = questions[index].ans2;
            a3.text = questions[index].ans3;
        }
    }

    //Called when all Questions are filled
    //Sets question page inactive and solution page active. 
    //Updates score
    public void Solve()
    {
        question.gameObject.SetActive(false);
        corrected.gameObject.SetActive(true);
       
        Scores.GetComponent<Score>().mCScore_2 = score;
        Scores.GetComponent<Score>().mCMax_2 = 5;
    }

    //Hardcoded Questions, Answers and Corrects.
    //Fills Questions List
    private void FillQuestions()
    {
        string quest;
        string ans1, ans2, ans3;
        int correct;

        quest = "Scotland Yard used a ___ technique by using blood hounds.";
        ans1 = "known";
        ans2 = "old";
        ans3 = "new";
        correct = 3;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "The Doctor that was called was ___.";
        ans1 = "George Baxter Phillips";
        ans2 = "Thomas Brown";
        ans3 = "John McCarthy";
        correct = 1;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "They entered the room ___.";
        ans1 = "immediately";
        ans2 = "after the blood hounds arrived";
        ans3 = "after they received orders to do so";
        correct = 3;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "Regarding the hounds, Scotland Yard ___.";
        ans1 = "paid a hugh sum to their owner";
        ans2 = "trained their own dogs";
        ans3 = "did not pay the owner";
        correct = 3;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "The door was eventually ___.";
        ans1 = "kicked in by a police man";
        ans2 = "choped down by the rooms owner";
        ans3 = "broken in by Inspector Abberline";
        correct = 2;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "How could anyone do this?";
        ans1 = "";
        ans2 = "";
        ans3 = "";
        correct = 0;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));
    }
}