using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Mitre Square Questioning Part 
//Setting witnesses
public class PoliceQuestioning : MonoBehaviour
{
    public GameObject 
        panel_Constables,  //panel where user choses constable to question
        panel_Questioning, //panel where user questions constables
        Watkins, Warren, Harvey; //three constables 

    public GameObject Picture, Map, Name, Text;

    public bool wat, war, lon; // wat = watkins, war = warren, lon = Harvey

    private void Start()
    {
        war = wat = lon = false;
    }

    //Set Display when other constable is chosen
    public void SetWatkins()
    {
        Picture.GetComponent<Image>().sprite = Watkins.GetComponentInChildren<Image>().sprite;
        Name.GetComponent<Text>().text = Watkins.GetComponentInChildren<Text>().text;
        Text.GetComponent<Text>().text = "I was on duty at Mitre - square on Saturday night.I have been in the force seventeen years. I went on duty at 9.45 upon my regular beat. " +
            "That extends from Duke-street, Aldgate, through Heneage-lane, a portion of Bury-street, through Cree-lane, into Leadenhall-street, along eastward into Mitre-street, " +
            "then into Mitre - square, round the square again into Mitre-street, then into King - street to St. James's-place, round the place, then into Duke-street, where I started from. " +
            "That beat takes twelve or fourteen minutes. I had been patrolling the beat continually from ten o'clock at night until one o'clock on Sunday morning.";
        wat = true;
        panel_Constables.SetActive(false);
        panel_Questioning.SetActive(true);
    }
    public void SetWarren()
    {
        Picture.GetComponent<Image>().sprite = Warren.GetComponentInChildren<Image>().sprite;
        Name.GetComponent<Text>().text = Warren.GetComponentInChildren<Text>().text;
        Text.GetComponent<Text>().text = "I am General Sir Charles Warren, police chief, the head of the London Metropolitan Police. I will answer to your questions.";
        war = true;
        panel_Constables.SetActive(false);
        panel_Questioning.SetActive(true);
    }
    public void SetHarvey()
    {
        Picture.GetComponent<Image>().sprite = Harvey.GetComponentInChildren<Image>().sprite;
        Name.GetComponent<Text>().text = Harvey.GetComponentInChildren<Text>().text;
        Text.GetComponent<Text>().text = " I was on duty in Goulston-street, Whitechapel, on Sunday morning, Sept. 30.";
        lon = true;
        panel_Constables.SetActive(false);
        panel_Questioning.SetActive(true);
    }

}
