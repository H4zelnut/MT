using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.IO;


//First Question Script
//Questions look like a notebook
public class Questions1 : MonoBehaviour
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
    int index;
    int score;
    string textAll;

    List<int> solution; //saves the chosen answer number 
    
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
                    textAll += "The victim lives in room no " + chosen + ". \n";
                    corrected.text += "The victim lives in room no<color=green> 13</color>. \n";
                    score += 1;
                }
                else
                {
                    textAll += "The victim lives in room no " + chosen + ". \n";
                    corrected.text += "The victim lives in room no<color=red> 13</color>. \n";
                }
                break;
            case 2:
                if (solution[1] == questions[1].correct)
                {
                    textAll += "The victims name is " + chosen + ". \n";
                    corrected.text += "The victims name is<color=green> Mary Kelly</color>. \n";
                    score += 1;
                }
                else
                {
                    textAll += "The victims name is " + chosen + ". \n";
                    corrected.text += "The victims name is<color=red> Mary Kelly</color>. \n";
                }
                break;
            case 3:
                if (solution[2] == questions[2].correct)
                {
                    textAll += "There are " + chosen + " rooms in Millers Court. \n";
                    corrected.text += "There are<color=green> 13 </color>rooms in Millers Court. \n";
                    score += 1;
                }
                else
                {
                    textAll += "There are " + chosen + " rooms in Millers Court. \n";
                    corrected.text += "There are<color=red> 13 </color>rooms in Millers Court. \n";
                }
                break;
            case 4:
                if (solution[3] == questions[3].correct)
                {
                    textAll += "The owner of Millers Court uses room number " + chosen + " for himself. \n";
                    corrected.text += "The owner of Millers Court uses room number<color=green> 27 </color>for himself. \n";
                    score += 1;
                }
                else
                {
                    textAll += "The owner of Millers Court uses room number " + chosen + " for himself. \n";
                    corrected.text += "The owner of Millers Court uses room number<color=red> 27 </color>for himself. \n";
                }
                break;
            case 5:
                if (solution[4] == questions[4].correct)
                {
                    textAll += "The victim had " + chosen + " neighbors. \n";
                    corrected.text += "The victim had<color=green> no </color>neighbors. \n";
                    score += 1;
                }
                else
                {
                    textAll += "The victim had " + chosen + " neighbors. \n";
                    corrected.text += "The victim had<color=red> no </color>neighbors. \n";
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
        Scores.GetComponent<Score>().mCScore_1 = score;
        Scores.GetComponent<Score>().mCMax_1 = 5;
    }

    //Hardcoded Questions, Answers and Corrects.
    //Fills Questions List
    private void FillQuestions()
    {
        string quest;
        string ans1, ans2, ans3;
        int correct;

        quest = "The victim lives in room no ___";
        ans1 = "2";
        ans2 = "9";
        ans3 = "13";
        correct = 3;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "The victims name is ___ ";
        ans1 = "Mary Kelly";
        ans2 = "Mary Ann Cox";
        ans3 = "Mary Keyler";
        correct = 1;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "There are ___ rooms in Millers Court.";
        ans1 = "12";
        ans2 = "14";
        ans3 = "13";
        correct = 3;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "The Owner of Millers Court uses room number ___ for himself.";
        ans1 = "1";
        ans2 = "12";
        ans3 = "27";
        correct = 3;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "The victim had ___ neighbors.";
        ans1 = "two";
        ans2 = "no";
        ans3 = "three";
        correct = 2;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));

        quest = "What happened there?";
        ans1 = "";
        ans2 = "";
        ans3 = "";
        correct = 0;
        questions.Add(new Question(quest, ans1, ans2, ans3, correct));
    }
}
