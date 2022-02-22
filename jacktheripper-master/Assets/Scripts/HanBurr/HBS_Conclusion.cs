using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// Conclusion Second Murder Quiz
public class HBS_Conclusion : MonoBehaviour
{
    public GameObject 
        indi1,  //First statement
        indi2,  //Second statement
        conc,   //Conclusion, drawable from two statements
        next, solve, // UI
        canvas; //Score.cs Object
    List<string> answers, indiz1, indiz2;
    int index; //tracks which question is currently up
    List<int> solution = new List<int>();

    private bool step, counter;
    // Start is called before the first frame update
    void Start()
    {
        answers = new List<string>();
        indiz1 = new List<string>();
        indiz2 = new List<string>();

        index = 0;
        step =  false;
        counter = true;
        FillList();
        SetNew();
        next.SetActive(false);
    }
    // Checks for final question
    private void Update()
    {
        if(index == 10 && step == false)
        {
            next.SetActive(true);
            solve.SetActive(false);
            int tmp = 0; // tracks score
            //if answer is correct, solution has a 1 in index. else 0
            foreach (int i in solution)
            {
                if (i == 1)
                {
                    tmp+=1;
                }
            }
            // Update score
            canvas.GetComponent<Score>().hBSscore_3 = tmp;
            canvas.GetComponent<Score>().hBSmax_3 = 5;
            step = true;
            // set quiz invisible if false
            indi1.SetActive(false);
            indi1.transform.parent.GetChild(1).gameObject.SetActive(false);
            indi1.transform.parent.GetChild(2).gameObject.SetActive(false);
            indi2.SetActive(false);
            indi2.transform.parent.GetChild(1).gameObject.SetActive(false);
            indi2.transform.parent.GetChild(2).gameObject.SetActive(false);
            conc.SetActive(false);
            conc.transform.parent.GetChild(1).gameObject.SetActive(false);
            conc.transform.parent.GetChild(2).gameObject.SetActive(false);
        }
    }

    // Check if answer is correct
    // colors correct answers green
    // lets false answers red
    // correct answers are shown in comments
    public void Solve()
    {
        if (!step)
        {
            counter = true;
            switch (index)
            {
                case 0:
                    //100
                    if(indi1.GetComponent<Text>().text == indiz1[index + 1])
                    {
                        indi1.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (indi2.GetComponent<Text>().text == indiz2[index])
                    {
                        indi2.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (conc.GetComponent<Text>().text == answers[index])
                    {
                       conc.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    break;
                case 2:
                    //001
                    if (indi1.GetComponent<Text>().text == indiz1[index])
                    {
                        indi1.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (indi2.GetComponent<Text>().text == indiz2[index])
                    {
                        indi2.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (conc.GetComponent<Text>().text == answers[index+1])
                    {
                        conc.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    break;
                case 4:
                    //101
                    if (indi1.GetComponent<Text>().text == indiz1[index + 1])
                    {
                        indi1.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (indi2.GetComponent<Text>().text == indiz2[index])
                    {
                        indi2.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (conc.GetComponent<Text>().text == answers[index+1])
                    {
                        conc.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    break;
                case 6:
                    //000
                    if (indi1.GetComponent<Text>().text == indiz1[index])
                    {
                        indi1.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (indi2.GetComponent<Text>().text == indiz2[index])
                    {
                        indi2.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (conc.GetComponent<Text>().text == answers[index])
                    {
                        conc.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    break;
                case 8:
                    //100
                    if (indi1.GetComponent<Text>().text == indiz1[index + 1])
                    {
                        indi1.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (indi2.GetComponent<Text>().text == indiz2[index])
                    {
                        indi2.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    if (conc.GetComponent<Text>().text == answers[index])
                    {
                        conc.GetComponent<Text>().color = Color.green;
                    }
                    else
                    {
                        counter = false;
                    }
                    break;
            }
            //If one wrong answer > Add 0
            if (counter == false)
            {
                solution.Add(0);
            }
            //If all correct > Add 1
            else
            {
                solution.Add(1);
            }
            step = true;
            solve.GetComponentInChildren<Text>().text = "Next";
        }
        else
        {
            indi1.GetComponent<Text>().color = Color.red;
            indi2.GetComponent<Text>().color = Color.red;
            conc.GetComponent<Text>().color = Color.red;
            index += 2;
            if (index <= 8)
            {
                SetNew();
            }
            step = false;
            solve.GetComponentInChildren<Text>().text = "Solve";
        }
    }

    // set new texts after each answered question
    void SetNew()
    {
        indi1.GetComponent<Text>().text = indiz1[index];
        indi2.GetComponent<Text>().text = indiz2[index];
        conc.GetComponent<Text>().text = answers[index];
    }
    //Change Text of first clue
    public void Klick1()
    {
        if(indi1.GetComponent<Text>().text == indiz1[index])
        {
            indi1.GetComponent<Text>().text = indiz1[index + 1];
        }
        else
        {
            indi1.GetComponent<Text>().text = indiz1[index];
        }
    }
    //Change Text of second clue
    public void Klick2()
    {
        if (indi2.GetComponent<Text>().text == indiz2[index])
        {
            indi2.GetComponent<Text>().text = indiz2[index + 1];
        }
        else
        {
            indi2.GetComponent<Text>().text = indiz2[index];
        }
    }
    //Change Text of conclusion 
    public void Klick3()
    {
        if (conc.GetComponent<Text>().text == answers[index])
        {
            conc.GetComponent<Text>().text = answers[index + 1];
        }
        else
        {
            conc.GetComponent<Text>().text = answers[index];
        }
    }

    //Hardcoded Texts
    //comments have solutions
    private void FillList()
    {
        //1: 211
        indiz1.Add("Doors to yard normally locked");
        indiz1.Add("Doors to yard normally unlocked");
        indiz2.Add("Yard was frequently used by strangers");
        indiz2.Add("Yard was rarely used by strangers");
        answers.Add("Murderer entered through the gates");
        answers.Add("Murderer climbed over the pailings");

        //2:  112
        indiz1.Add("There were multiple patches of blood");
        indiz1.Add("Pailings and floor was clean");
        indiz2.Add("There were splashes of blood facing away");
        indiz2.Add("The mud didnt leave traces");
        answers.Add("Victim was probably dragged there");
        answers.Add("Victim was killed there");

        //3:  212
        indiz1.Add("Leather Apron probably belonged to murderer");
        indiz1.Add("Leather Apron belonged to someone else");
        indiz2.Add("John Pizer aka Leather Apron had an alibi");
        indiz2.Add("John Pizer aka Leather Apron had no alibi");
        answers.Add("John Pizer is probably gilty");
        answers.Add("John Pizer is not guilty");

        //4:  111
        indiz1.Add("Incisions were clean");
        indiz1.Add("Incisions were random");
        indiz2.Add("Victims entrails were intact when removed");
        indiz2.Add("Victims entrails were torn when removed");
        answers.Add("Murderer acts methodically");
        answers.Add("Murderer likes to destroy");

        //5: 211
        indiz1.Add("There were voices in the yard at night");
        indiz1.Add("It was silent the whole time");
        indiz2.Add("Victims tongue was swollen");
        indiz2.Add("Victims tongue was removed");
        answers.Add("Victim was suffocated");
        answers.Add("Victim was drunk");
    }
}
