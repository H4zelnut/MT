using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

// Newspaper Quiz DY and MS
// Yes No questions
public class Newspaper : MonoBehaviour
{
    public GameObject Question, next, panel, canvas;
    public Text R, L;

    List<string> questions, explanations;
    List<int> correct, tmp;
    List<string> answers;       //explanations for correct answers
    List<string> right, left;   //answer possibilities for left and right side
    int score;

    void Start()
    {
        next.SetActive(false);
        questions = new List<string>();
        explanations = new List<string>();
        answers = new List<string>();
        correct = new List<int>();
        right = new List<string>();
        left = new List<string>();
        score = 0;
        FillQuests();

        Question.GetComponentInChildren<Text>().text = questions[0];
        questions.RemoveAt(0);

    }

    // Hardcoded Questions and Answers
    // Solutions 
    void FillQuests()
    {
        questions.Add("The police is well equipped"); //No
        //left.Add("Yes");
        //right.Add("No");
        correct.Add(1);
        explanations.Add("The police was poorly equipped. They used simple, man powered, wooden carts for carrying bodies. If they weren't offered blankets from near residents, they didn't cover the body.");

        questions.Add("The police is investigating the murders"); // Yes
        left.Add("Yes");
        right.Add("No");
        correct.Add(0);
        explanations.Add("The police wrote down names of witnesses and family members of victims and ordered them to court hearings where they had to answer to a coroner.");

        questions.Add("The police is giving out information about the murders"); // Yes
        left.Add("Yes");
        right.Add("No");
        correct.Add(0);
        explanations.Add("The police released not only the letters, but also the investigation progress to the press. By releasing the name Jack the Ripper, they started a wave of fake letters.");

        questions.Add("The police is close to catching Jack the Ripper"); // No
        left.Add("Yes");
        right.Add("No");
        correct.Add(1);
        explanations.Add("Both bodies were found not long after they were murdered. He was seen multiple times by witnesses that gave their statements, but he wasn't found.");

        questions.Add("The police is showing realistic pictures"); // No
        left.Add("Yes");
        right.Add("No");
        correct.Add(1);
        explanations.Add("In the police newspaper, they used stereotypical men faces as murder suspects and wrong body examination pictures.");

        questions.Add("Why does the police reveal information?"); // To show the people they are investigating
        left.Add("To show the people they are investigating");
        right.Add("To demonstrate the cruelty of Jack the Ripper");
        correct.Add(0);
        explanations.Add("The people started to feel unsafe and were discontent with the police, blaming them for not finding the murderer. To show the people that they do investigate, they released the information they found.");

        questions.Add("Why did Warren order to erase the grafitto?"); // To prevent more riots against jews
        left.Add("To prevent more riots against jews");
        right.Add("To hide the fact that the apron piece was found so late");
        correct.Add(0);
        explanations.Add("Warren tried to keep the information about the grafitto inside the police. He wanted to prevent more riots against jews, who were already connected to Jack the Ripper, as John Pizer was a jew;");

        questions.Add("Why was the grafitto in the newspaper, then?"); // Different police institutes do not work together
        left.Add("They were sure Jack the Ripper was indeed a jew");
        right.Add("Different police institutes do not work together");
        correct.Add(1);
        explanations.Add("Warren, as part of the Metropolitan Police, had the Grafitto erased. The head of the City Police Comissioner considered this a huge blunder and released the information in the Police Newspaper." +
            "This controversy made the information about the grafitto spread like a wild fire. However, the wide-scale anti-semitism that Warren feared did not break out again.");

        questions.Add("The appron was found approximately two hours after the murder. What does this mean?"); // Both
        left.Add("He went home and came back");
        right.Add("He waited until the coast was clear and put it there");
        correct.Add(2);
        explanations.Add("There is no wrong answer to this question. The apron piece was reportedly not there at 2:30AM but it was at 2:55AM. The route that Jack the Ripper took probably led to his home or hideout." +
            "By the time he took of from Mitre Square, the region was flooded with police. He either had to submerge at home or inside a hideout.");

        questions.Add("There was almost no blood on the apron piece. What does that tell about the murderer?"); // behind
        left.Add("He washed his hands after the murder");
        right.Add("He made sure the blood did not get onto him");
        correct.Add(1);
        explanations.Add("Eddowes followed the ripper in search of a private moment. Taking his coat off wouldn't have seemed suspicious for the victims and putting it back on after the murder would have hidden the bloodstains underneath." +
            "Would he have washed his handy right after, he would have been seen to do so by policemen that flooded the region.");
        
    }

    // Called when Right Answer was clicked
    // Check if Right Answer is correct > text becomes green, else red
    public void Left()
    {
        if (questions.Count != 0)
        {
            if (correct[0] == 0 || correct[0] == 2)
            {
                panel.GetComponentInChildren<Text>().color = Color.green;
                answers.Add("correct");
                score += 1;
            }
            else
            {
                panel.GetComponentInChildren<Text>().color = Color.red;
                answers.Add("wrong");
            }

            Question.GetComponent<Text>().text = questions[0];
            correct.RemoveAt(0);
            questions.RemoveAt(0);
            L.text = left[0];
            R.text = right[0];
            left.RemoveAt(0);
            right.RemoveAt(0);
            panel.GetComponentInChildren<Text>().text = explanations[0];
            explanations.RemoveAt(0);
            panel.SetActive(true);
        }
        else
        {
            next.SetActive(true);
            Question.GetComponent<Text>().text = "The investigation of the double event is now closed for good.";
            canvas.GetComponent<Score>().dMScore_2 = score;
            canvas.GetComponent<Score>().dMmax_2 = answers.Count;
            next.SetActive(true);
            L.transform.parent.gameObject.SetActive(false);
            R.transform.parent.gameObject.SetActive(false);

        }
        if (questions.Count == 1)
        {
            next.SetActive(true);
            Question.GetComponent<Text>().text = "The investigation of the double event is now closed for good.";
            canvas.GetComponent<Score>().dMScore_2 = score;
            canvas.GetComponent<Score>().dMmax_2 = answers.Count;
            next.SetActive(true);
            L.transform.parent.gameObject.SetActive(false);
            R.transform.parent.gameObject.SetActive(false);
        }
    }
    // Called when Right Answer was clicked
    // Check if Right Answer is correct > text becomes green, else red
    public void Right()
    {
        if (questions.Count != 0)
        {
            if (correct[0] == 1 || correct[0] == 2)
            {
                panel.GetComponentInChildren<Text>().color = Color.green;
                answers.Add("correct");
                score += 1;
            }
            else
            {
                panel.GetComponentInChildren<Text>().color = Color.red;
                answers.Add("wrong");
            }
            Question.GetComponent<Text>().text = questions[0];
            correct.RemoveAt(0);
            questions.RemoveAt(0);
            L.text = left[0];
            R.text = right[0];
            left.RemoveAt(0);
            right.RemoveAt(0);
            panel.GetComponentInChildren<Text>().text = explanations[0];
            explanations.RemoveAt(0);
            panel.SetActive(true);
        }
        else
        {
            next.SetActive(true);
            Question.GetComponent<Text>().text = "The investigation of the double event is now closed for good.";
            canvas.GetComponent<Score>().dMScore_2 = score;
            canvas.GetComponent<Score>().dMmax_2 = answers.Count;
            next.SetActive(true);
            L.transform.parent.gameObject.SetActive(false);
            R.transform.parent.gameObject.SetActive(false);

        }
        if (questions.Count == 1)
        {
            next.SetActive(true);
            Question.GetComponent<Text>().text = "The investigation of the double event is now closed for good.";
            canvas.GetComponent<Score>().dMScore_2 = score;
            canvas.GetComponent<Score>().dMmax_2 = answers.Count;
            next.SetActive(true);
            L.transform.parent.gameObject.SetActive(false);
            R.transform.parent.gameObject.SetActive(false);
        }
    }

    //Close Panel with explanation
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
