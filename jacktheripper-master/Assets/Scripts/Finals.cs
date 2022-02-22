using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Final Score Page 
//Called as last page in game
public class Finals : MonoBehaviour
{
    public GameObject ScoreObj, TextObj;
    Score scoreScript;
    string score1, score2, score3, score4, conclusion;
    void Start()
    {
        scoreScript = ScoreObj.GetComponent<Score>();
        conclusion = "";
        Calculate();
        TextObj.GetComponent<Text>().text = score1+score2+score3+score4+conclusion;
    }

    //Calculates scores for each case and puts them into nice string
    void Calculate()
    {
        score1 = "Case 1: Mary Ann Nichols\n"
           + "Investigation of the murder scene: " + scoreScript.bRscore_1 + "/" + scoreScript.bRmax_1 + "\n"
           + "Time Reconstruction: " + scoreScript.bRscore_2 + "/" + scoreScript.bRmax_2 + "\n"
           + "Murder Place: " + scoreScript.bRscore_3 + "/" + scoreScript.bRmax_3 + "\n" + "\n";
        score2 = "Case 2: Annie Chapman\n"
           + "Investigation of the murder scene: " + scoreScript.hBSscore_1 + "/" + scoreScript.hBSmax_1 + "\n"
           + "Relations of witnesses: " + scoreScript.hBSscore_2 + "/" + scoreScript.hBSmax_2 + "\n"
           + "Conclusion: " + scoreScript.hBSscore_3 + "/" + scoreScript.hBSmax_3 + "\n" + "\n";
        score3 = "Case 3 and 4: Elizabeth Stride and Catherine Eddowes\n"
           + "Newspaper Evaluation: " + scoreScript.dMScore_1 + "/" + scoreScript.dMmax_1 + "\n"
           + "Conclusion Double Murder: " + scoreScript.dMScore_2 + "/" + scoreScript.dMmax_2 + "\n" + "\n";
        score4 = "Case 5: Mary Kelly\n"
           + "Finding the Apartment: " + scoreScript.mCScore_1 + "/" + scoreScript.mCMax_1 + "\n"
           + "Police Work Analysis: " + scoreScript.mCScore_2 + "/" + scoreScript.mCMax_2 + "\n"
           + "Inquest Conclusion: " + scoreScript.mCScore_3 + "/" + scoreScript.mCMax_3 + "\n";
        int finalScore =
            scoreScript.bRscore_1 + scoreScript.bRscore_2 + scoreScript.bRscore_3 +
            scoreScript.hBSscore_1 + scoreScript.hBSscore_2 + scoreScript.hBSscore_3 +
            scoreScript.dMScore_1 + scoreScript.dMScore_2 +
            scoreScript.mCScore_1 + scoreScript.mCScore_2 + scoreScript.mCScore_3;
        int finalScoreMax =
        scoreScript.bRmax_1 + scoreScript.bRmax_2 + scoreScript.bRmax_3 +
        scoreScript.hBSmax_1 + scoreScript.hBSmax_2 + scoreScript.hBSmax_3 +
        scoreScript.dMmax_1 + scoreScript.dMmax_2 +
        scoreScript.mCMax_1 + scoreScript.mCMax_2 + scoreScript.mCMax_3;

        conclusion = "\n" + "Final Score: " + finalScore + "/" + finalScoreMax;
    }

    //Close Game 
    public void CloseGame()
    {
        Application.Quit();
    }
}
