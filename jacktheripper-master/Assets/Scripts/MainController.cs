using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles current Dates and Date Skips

public class MainController : MonoBehaviour
{
    //Dates (each day that the game playes in)
    //A Day consists of a quest index:
    //      0: Investigationtime
    //      1: Quiztime
    //Each day has an Investigation time and a Quiztime.
    struct Date
    {
        public int day;
        public int month;
        public int year;
        public int quest; 

        public Date(int theDay, int theMonth, int theYear, int theQuest)
        {
            day = theDay;
            month = theMonth;
            year = theYear;
            quest = theQuest;
        }
    };
    // Dates when victims died
    private List<Date> dates; 
    private Date currentDate;
    public int index;
    // Needed for Zoomer.cs, called from there
    // When this is true, Hanburry Street Target appears on the map (handeled in Zoomer.cs)
    public bool annie;

    //Interface
    public Text displayedDate;
    public GameObject left;
    public GameObject right;

    //Instructionscreen, scores and Textfield
    public GameObject Instructions;
    public GameObject Scores;
    public Text text;

    //Summary when Arrow Down
    public GameObject Notebook;

    //Inventory (Top) 
    public GameObject Inventar_Objects;
    public GameObject Inventar_Statements;
    public GameObject Inventar_Back;
    public GameObject Inventar_Question;
    
    //Skip Date
    public GameObject Next;

    //Hint Texts
    public Text Hint;

    //Final Screen on last Day (with summary of scores and possibility to close the game)
    public GameObject End;

    // Events
    #region Bucks Row
    //BR_Quiz 1:
    public GameObject Questions;
    //BR_Investigation 2:
    public GameObject Statements;
    //BR_Quiz 2:
    public GameObject TimeReckon;
    //BR Quiz 3:
    public GameObject BR_Conclusion;
    #endregion
    #region Hanburry Street
    //HBS Quiz 1:
    public GameObject HBS_Sorting;
    //HBS Investigation 2:
    public GameObject HBS_Dialogue;
    //HBS Investigation 2.2:
    public GameObject HBS_Dialogue_12;
    //HBS Investigation 2.3:
    public GameObject HBS_Dialogue_13;
    //HBS Quiz 2:
    public GameObject HBS_Relations;
    //HBS Quiz 3:
    public GameObject HBS_Conclusion;
    #endregion
    #region Dutfields Yard and Mitre Square
    //DY Investigation 1:
    public GameObject DY_Questioning;
    //MS Investigation 1:
    public GameObject MS_Questioning;
    //Saucy Jack Postcard
    public GameObject SaucyJack;
    //Dear Boss Letter
    public GameObject DearBoss;
    //From Hell Letter
    public GameObject FromHell;
    //Newspaper ParentObject
    public GameObject Newspaper;
    //Newspaper 1
    public GameObject Newspaper1;
    //Newspaper 2
    public GameObject Newspaper2;
    //Quiz 1:
    public GameObject Fragestunde;
    //Quiz 2:
    public GameObject Finals;
    #endregion
    #region Millers Court
    //Investigation 1 & Quiz 1+2:
    public GameObject Dorset_1;
    //Investigation 2 & Quiz 3:
    public GameObject Dorset_2;
    #endregion

    void Start()
    {
        annie = false;
        index = 0;
        // fill with dates of Game
        dates = new List<Date>();
        dates.Add(new Date(31, 08, 1888, 0)); // Mary Ann Nichols death                             0
        dates.Add(new Date(01, 09, 1888, 0)); // Mary Ann Nichols victims statements                1
        dates.Add(new Date(08, 09, 1888, 0)); // Annie Chapman death                                2
        dates.Add(new Date(10, 09, 1888, 0)); // Annie Chapman Investigation                        3
        dates.Add(new Date(12, 09, 1888, 0)); // Annie Chapman Investigation                        4
        dates.Add(new Date(13, 09, 1888, 0)); // Annie Chapman Investigation+Relations              5
        dates.Add(new Date(22, 09, 1888, 0)); // Mary Ann Nichols Closed                            6
        dates.Add(new Date(26, 09, 1888, 0)); // Annie Chapman Closed                               7
        dates.Add(new Date(30, 09, 1888, 0)); // Elizabeth Stride death + Catherine Eddowes death   8
        dates.Add(new Date(01, 10, 1888, 0)); // Saucy Jack + Dear Boss                             9
        //dates.Add(new Date(11, 10, 1888, 1)); // Catherine Eddowes Closed                           
        dates.Add(new Date(16, 10, 1888, 0)); // From Hell Letter                                   10
        dates.Add(new Date(20, 10, 1888, 0)); // Newspaper and Letters                              11
        dates.Add(new Date(23, 10, 1888, 0)); // Elizabeth Stride Closed                            12                    
        dates.Add(new Date(09, 11, 1888, 0)); // Mary Jane Kelly Death death                        13
        dates.Add(new Date(12, 11, 1888, 0)); // Inquest MJK                                        14
        dates.Add(new Date(19, 11, 1888, 0)); // Mary Jane Kelly Closed                           

        currentDate = dates[index];
        displayedDate.text = "" + currentDate.day + "." + currentDate.month + "." + currentDate.year;
        Instructions.SetActive(true);
    }

    //If Skip clicked 
    //> Change to next date, if Quiztime (1)
    //  or to Quiztime (1) if Investigationtime (0) 
    public void ChangeDate()
    {
        // Clear Hinttext > No old hints
        Hint.text = "";
        Hint.transform.parent.gameObject.SetActive(false);
        Hint.transform.parent.parent.gameObject.SetActive(false);

        // if Quiztime over
        if (dates[index].quest == 1)
        {   
            // if not last event
            // only for safety reasons, the final screen appears as last event
            // after that > no skip available!
            if (index < dates.Count)
            {
                index += 1;
                currentDate = dates[index];
                SetDate(currentDate);
                right.SetActive(true);
                left.SetActive(true);
                StartInstructions();
            }
        }
        //if investigationtime over
        else
        {
            Date tmp = new Date(dates[index].day, dates[index].month, dates[index].year, 1);
            dates[index] = tmp;
            left.SetActive(false);
            right.SetActive(false);
            StartEvent();
        }
    }

    // Visual corrections
    // if day or month are between 1-9, set initial 0 
    // so instead of 1.1.2021 > 01.01.2021
    // just for the looks
    void SetDate(Date currentDate)
    {
        if (currentDate.day < 10 && currentDate.month < 10)
        {
            displayedDate.text = "0" + currentDate.day + ".0" + currentDate.month + "." + currentDate.year;
        }
        else if (currentDate.day < 10)
        {
            displayedDate.text = "0" + currentDate.day + "." + currentDate.month + "." + currentDate.year;
        }
        else if (currentDate.month < 10)
        {
            displayedDate.text = "" + currentDate.day + ".0" + currentDate.month + "." + currentDate.year;
        }
        else
        {
            displayedDate.text = "" + currentDate.day + "." + currentDate.month + "." + currentDate.year;
        }
    }

    // Start Quiztime
    // If Date index switches to 1
    // aka: Same Date, next Event
    void StartEvent()
    {
        switch (index)
        {
            case 0:
                //Questions
                Questions.SetActive(true);
                break;
            case 1:
                //TimeReckon
                Next.SetActive(false);
                Inventar_Objects.SetActive(true);
                Inventar_Back.SetActive(true);
                Statements.SetActive(false);
                TimeReckon.SetActive(true);
                break;
            case 2:
                Instructions.GetComponentInChildren<Text>().text
                    = "You have found evidence on the scene of crime. Decide for every single one how you would categorize them.";
                Instructions.SetActive(true);
                HBS_Sorting.SetActive(true);
                break;
            case 3:
                HBS_Dialogue.SetActive(false);
                ChangeDate();
                break;
            case 4:
                HBS_Dialogue.SetActive(false);
                ChangeDate();
                break;
            case 5:
                Hint.text = "Sometimes multiple persons can fit into the relation";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                // Relations
                HBS_Dialogue.SetActive(false);
                HBS_Relations.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                   = "You have seen multiple Statements and a newspaper article. \n" +
                   "How were these people related to each other? " +
                   "Answer the following questions!";
                Instructions.SetActive(true);
                break;
            case 6:
                //Conclusion Polly
                BR_Conclusion.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                    = "Mary Ann Nichols died in the night of the 31st of August 1888. " +
                    "Her murderer was never found but she is the first of five canonical victims of Jack the Ripper." +
                    "Due to refugees, mainly from Russia, Londons East End population swelled up to 80.000 inhabitants.\n" +
                    "Work and housing conditions worsened steadily. More than 50% of children born there died before the age of 5. \n" +
                    "The situation made robbery, violence, and alcohol dependency commonplace and drove women into prostitution.\n \n";
                Instructions.transform.GetChild(1).gameObject.SetActive(false);
                Instructions.transform.GetChild(2).gameObject.SetActive(true);
                Instructions.SetActive(true);
                Next.SetActive(true);
                int tmpS = GetComponent<Score>().bRscore_1 + GetComponent<Score>().bRscore_2 + GetComponent<Score>().bRscore_3;
                int tmpM = GetComponent<Score>().bRmax_1 + GetComponent<Score>().bRmax_2 + GetComponent<Score>().bRmax_3;
                Scores.GetComponentInChildren<Text>().text = "Your Score: \n" +
                    "Investigation of the murder scene: " + GetComponent<Score>().bRscore_1 + "/" + GetComponent<Score>().bRmax_1 + ".\n" +
                    "Time Reconstruction: " + GetComponent<Score>().bRscore_2 + "/" + GetComponent<Score>().bRmax_2 + ".\n" +
                    "Murder Place: " + GetComponent<Score>().bRscore_3 + "/" + GetComponent<Score>().bRmax_3 + ". \n \n" +
                    "Final Score: " + tmpS + "/" + tmpM;
                text.text += "\n" + "Case 1: " + tmpS + "/" + tmpM + "\n";
                string tmp, tmp2;
                tmp = "Victim: Mary Ann Nichsols\nWorked in a workhouse\nKnown prostitute";
                tmp2 = "\nThroat was cut \nBody mutilated \nNo Cart tracks found\n";
                Notebook.GetComponent<Notebook>().Insert(tmp, tmp2, 1);
                break;
            case 7:
                //Conclusion Annie1
                HBS_Conclusion.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                    = "Annie Chapman died in the night of the 08th of August 1888, only 8 days after Mary Ann Nichols. \n " +
                    "By the time she died, the press assumed she died by the hands of a killer that has already taken 3 other victims. \n " +
                    "Back then, Dr. Phillips testified, that Jack the Ripper must have had anatomical knowledge. \n " +
                    "Today, we know that he did not. More likely, he must have suffered from a disorder and collected body parts as trophies. \n" +
                    "In 1888, detectives were sparse and police work not yet refind. The Jack the Ripper murders only added to the need of a police reform.";
                Instructions.transform.GetChild(1).gameObject.SetActive(false);
                Instructions.transform.GetChild(2).gameObject.SetActive(true);
                Instructions.SetActive(true);

                Next.SetActive(true);
                tmpS = GetComponent<Score>().hBSscore_1 + GetComponent<Score>().hBSscore_2 + GetComponent<Score>().hBSscore_3;
                tmpM = GetComponent<Score>().hBSmax_1 + GetComponent<Score>().hBSmax_2 + GetComponent<Score>().hBSmax_3;
                Scores.GetComponentInChildren<Text>().text = "Your Score: \n" +
                    "Investigation of the murder scene: " + GetComponent<Score>().hBSscore_1 + "/" + GetComponent<Score>().hBSmax_1 + ".\n" +
                    "Relations of witnesses: " + GetComponent<Score>().hBSscore_2 + "/" + GetComponent<Score>().hBSmax_2 + ".\n" +
                    "Conclusion: " + GetComponent<Score>().hBSscore_3 + "/" + GetComponent<Score>().hBSmax_3 + ". \n \n" +
                    "Final Score: " + tmpS + "/" + tmpM;
                text.text += "\n" + "Case 2: " + tmpS + "/" + tmpM + "\n";
                tmp = "Victim: Annie Chapman\nKnown prostitute";
                tmp2 = "\nThroat was cut \nBody mutilated \n";
                Notebook.GetComponent<Notebook>().Insert(tmp, tmp2, 2);
                break;
            case 8:
                Hint.text = "Question witnesses again when there is new input";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                MS_Questioning.SetActive(true);
                DY_Questioning.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                   = "You heard, that the same night, a second murder occured. Another police team handled the witnesses. Let's see what they can to tell.";
                Instructions.SetActive(true);
                break;
            case 9:
                MS_Questioning.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                   = "Today, the 1st of October, a postcard arrived. The policemen who handed it to you called it the Saucy Jack postcard.";
                Instructions.SetActive(true);
                DearBoss.SetActive(false);
                SaucyJack.SetActive(true);
                break;
            case 10:
                DearBoss.SetActive(false);
                SaucyJack.SetActive(false);
                FromHell.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                  = "Catherine Eddowes murder case was closed on the 11th of October. Lets have a recap about what we found out.";
                Instructions.SetActive(true);
                Fragestunde.SetActive(true);
                break;
            case 11:
                Hint.text = "Take a CLOSER look at the newspaper";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                Newspaper2.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                 = "Another Strip was realeased. Lets see how the police sees the cases.";
                break;
            case 12:
                Finals.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                    = "At the age of 21 Elizabeth Stride was already registered as a prostitute. After her marriage, she worked in a coffehouse until she was forced to the workhouse after the couple split up. " +
                    "She had to return to occasional prostitution to earn her doss money. \nCatherine Eddowes was one of 10 siblings. After the break up with her " +
                    "husband, she lived with her partner in a poorhouse and helped to stay afloat with occasional prostitution. On the night of her death, she inteded to go home, but instead turned the " +
                    "other way, probably to drink some more. A decision that cost her life.";
                Instructions.transform.GetChild(1).gameObject.SetActive(false);
                Instructions.transform.GetChild(2).gameObject.SetActive(true);
                Instructions.SetActive(true);
                Next.SetActive(true);

                int tmpDY = GetComponent<Score>().dMScore_1 + GetComponent<Score>().dMScore_2;
                int tmpMS = GetComponent<Score>().dMmax_1 + GetComponent<Score>().dMmax_2;
                Scores.GetComponentInChildren<Text>().text = "Your Score: \n" +
                    "Newspaper Evaluation: " + GetComponent<Score>().dMScore_1 + "/" + GetComponent<Score>().dMmax_1 + ".\n" +
                    "Conclusion Double Murder: " + GetComponent<Score>().dMScore_2 + "/" + GetComponent<Score>().dMmax_2 + ".\n" +
                    "Final Score: " + tmpDY + "/" + tmpMS;
                text.text += "\n" + "Case 3&4: " + tmpDY + "/" + tmpMS + "\n";
                tmp = "Victim: Elizabeth Stride\nKnown prostitute";
                tmp2 = "\nThroat was cut \nMurderer didn't finish\n";
                Notebook.GetComponent<Notebook>().Insert(tmp, tmp2, 3);
                tmp = "Victim: Catherine Eddows\nKnown prostitute";
                tmp2 = "\nThroat was cut \nBody mutilated\nEvidence found at Gravitto";
                Notebook.GetComponent<Notebook>().Insert(tmp, tmp2, 4);
                break;
            case 13:
                Dorset_1.SetActive(false);
                Dorset_2.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                    = "Three days after the murder the one and only Inquest day begins.";
                Instructions.SetActive(true);
                break;
            case 14:
                Dorset_2.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                    = "Mary Kellys case was closed on the 19th of November 1888. Jack the Ripper preyed upon ‘unfortunates' in the slums in and around Whitechapel, London. " +
                    "These were women who, due to extreme poverty, were driven to prostitution in order to sustain themselves. Most of his victims were women in their forties, " +
                    "apart from young Mary Jane Kelly, who was only in her mid-twenties at the time of her murder.It is unclear as to what fueled his savage bloodlust, but the murders all seemed" +
                    " to be methodical and calculating. The precise number of Ripper victims is not definite, but it is generally accepted that he killed five women, all of them prostitutes. " +
                    "His victim's throats were cut, often followed by abdominal mutilations, including organ removal in some cases.";
                Instructions.transform.GetChild(1).gameObject.SetActive(false);
                Instructions.transform.GetChild(2).gameObject.SetActive(true);
                Instructions.SetActive(true);
                Next.SetActive(true);

                int tmpMC = GetComponent<Score>().mCScore_1 + GetComponent<Score>().mCScore_2 + GetComponent<Score>().mCScore_3;
                int tmpMCMax = GetComponent<Score>().mCMax_1 + GetComponent<Score>().mCMax_2 + GetComponent<Score>().mCMax_3;
                Scores.GetComponentInChildren<Text>().text = "Your Score: \n" +
                    "Finding the Apartment: " + GetComponent<Score>().mCScore_1 + "/" + GetComponent<Score>().mCMax_1 + ".\n" +
                    "Police Work Analysis: " + GetComponent<Score>().mCScore_2 + "/" + GetComponent<Score>().mCMax_2 + ".\n" +
                    "Inquest Conclusion: " + GetComponent<Score>().mCScore_3 + "/" + GetComponent<Score>().mCMax_3 + ".\n" +
                    "Final Score: " + tmpMC + "/" + tmpMCMax;
                text.text += "\n" + "Case 5: " + tmpMC + "/" + tmpMCMax + "\n";
                tmp = "Victim: Mary Kelly\nKnown prostitute\nyoung";
                tmp2 = "\nThroat was cut \nBody heavily mutilated \n";
                Notebook.GetComponent<Notebook>().Insert(tmp, tmp2, 5);
                break;
        }
    }

    // Start Investigationtime
    // If Date index swtiches to 0 
    // aka: Next Date
    void StartInstructions()
    {
        switch (index)
        {
            case 1:
                Hint.text = "How was the course of events?"; 
                Hint.transform.parent.parent.gameObject.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                    = "Here are some reports of todays witnesses in court. Study them well, so you can answer tonights test.";
                Instructions.SetActive(true);
                Statements.SetActive(true);
                break;
            case 2:
                TimeReckon.SetActive(false);
                annie = true;
                Instructions.GetComponentInChildren<Text>().text
                    = "Another Victim was found tonight at Hanburry Street. Go check it out.";
                Instructions.SetActive(true);
                break;
            case 3:
                Hint.text = "How are these persons related?";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                HBS_Dialogue.SetActive(true);
                HBS_Sorting.SetActive(false);
                Inventar_Objects.SetActive(false);
                Inventar_Back.SetActive(false);
                Inventar_Statements.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                Next.SetActive(true);
                break;
            case 4:
                Hint.text = "How was the course of events?";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                left.SetActive(false);
                right.SetActive(false);
                // Questioning of Richardson, Smith, Green, Kent
                HBS_Dialogue_12.SetActive(true);
                HBS_Dialogue.SetActive(true);
                left.SetActive(false);
                break;
            case 5:
                Hint.text = "How was the course of events?";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                left.SetActive(false);
                right.SetActive(false);
                // Questioning of Pizer, Chandler, Phillips
                HBS_Dialogue_13.SetActive(true);
                HBS_Dialogue.SetActive(true);
                break;
            case 6:
                //Conslusion First Murder
                HBS_Relations.SetActive(false);
                Inventar_Statements.SetActive(true);
                Inventar_Objects.SetActive(true);
                Inventar_Question.SetActive(true);
                Inventar_Back.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                    = "Newspaper articles regarding the murder of Mary Ann Nichols deduce that the murder must have happened elsewhere. " +
                    "According to these articles, the body must have been dragged there. Is this true?";
                Instructions.SetActive(true);
                BR_Conclusion.SetActive(true);
                left.SetActive(false);
                right.SetActive(false);
                break;
            case 7:
                Instructions.transform.GetChild(1).gameObject.SetActive(true);
                Instructions.transform.GetChild(2).gameObject.SetActive(false);
                //Conclusion second Murder
                left.SetActive(false);
                right.SetActive(false);
                Inventar_Statements.SetActive(false);
                Inventar_Objects.SetActive(false);
                Inventar_Question.SetActive(false);
                Inventar_Back.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                   = "As well as Nichols case, Chapmans case will be closed today. What did we find out?";
                Instructions.SetActive(true);
                HBS_Conclusion.SetActive(true);
                break;
            case 8:
                Hint.text = "Question witnesses again when there is new input";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                Instructions.transform.GetChild(1).gameObject.SetActive(true);
                Instructions.transform.GetChild(2).gameObject.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
                DY_Questioning.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                   = "Another Victim was found tonight and Dutfields Yard. Question the witnesses.";
                Instructions.SetActive(true);
                break;
            case 9:
                left.SetActive(false);
                right.SetActive(false);
                MS_Questioning.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                   = "As promised, you received the 'Dear Boss' letter. Take a look at it.";
                Instructions.SetActive(true);
                DearBoss.SetActive(true);
                break;
            case 10:
                left.SetActive(false);
                right.SetActive(false);
                SaucyJack.SetActive(false);
                FromHell.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                   = "More and more Newspaper report of Jack the Ripper and the people get angry, because he is still out there and Home Guards try to ensure Whitechapel. " +
                   "Today, George Lusk, chairman of the Home Guard reveiced a package. A Letter, with the words 'From Hell' on the envelope was in it, together with half a Kidney." +
                   "He forwareded the letter to be inspected.";
                Instructions.SetActive(true);
                break;
            case 11:
                Hint.text = "Take a CLOSER look at the newspaper";
                Hint.transform.parent.parent.gameObject.SetActive(true);

                left.SetActive(false);
                right.SetActive(false);
                Fragestunde.SetActive(false);
                Newspaper.SetActive(true);
                Newspaper1.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                   = "As the investigation proceeds, the people are loosing confidence in the police. To show that they are still investigation, the police realeases comic strips in their polices news paper.";
                Instructions.SetActive(true);
                break;
            case 12:
                left.SetActive(false);
                right.SetActive(false);
                Finals.SetActive(true);
                Newspaper.SetActive(false);
                Instructions.GetComponentInChildren<Text>().text
                   = "Today, Elizabeths Stride investigation is also going to be closed. It is time to recall what happened. Answer the follwing questions.";
                Instructions.SetActive(true);
                break;
            case 13:
                left.SetActive(false);
                right.SetActive(false);
                Dorset_1.SetActive(true);
                Instructions.GetComponentInChildren<Text>().text
                   = "Again, tonight a murder happened. Lets follow the story behind the murder.";
                Instructions.SetActive(true);
                break;
            case 14:
                left.SetActive(false);
                right.SetActive(false);
                Dorset_2.transform.GetChild(0).gameObject.SetActive(false);
                Dorset_2.transform.GetChild(1).gameObject.SetActive(false);
                Dorset_2.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 15:
                left.SetActive(false);
                right.SetActive(false);
                End.SetActive(true);
                Next.SetActive(false);
                break;
        }
    }

    // Helper Method for Debugging and Skipping to current date
    // Not called ingame in final version
    // For use: Change Date
    public void Skip( int date)
    {
        Date tmp = new Date(dates[date].day, dates[date].month, dates[date].year, 0);
        ChangeDate();
        Next.SetActive(true);
    }
}
