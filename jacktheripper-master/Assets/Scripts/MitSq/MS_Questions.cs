using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Mitre Square Questioning Part 
//Question Witnesses
public class MS_Questions : MonoBehaviour
{
    public GameObject Map, Text, Next,
        hintParent, Police; //hintParent only used to fill hints list 
    public Sprite route_watkins, graffito, bar, station, club, mitre; //Pressing statements as sprites

    private List<GameObject> hints;
    private bool map1, map2, map3, map4;

    /*
     * 0: eddowes
     * 1: map /route
     * 2: warren
     * 3: long
     * 4: blood/wounds
     * 5: jews
     * 6: Dear Boss
     * 7: Elizabeth Stride
     * 8: 
     * */

    private void Start()
    {
        hints = new List<GameObject>(); // contains all sprite Objects
        foreach (Transform t in hintParent.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.name == "Image")
            {
                hints.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
        hints[0].SetActive(true);
        map1 = map2 = map3 = map4 = false;
    }
    // if clue is clicked: check for active witness
    // Change text
    #region clues
    public void clicked_Eddowes()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "The victims name was Catherine Eddowes. We found a Pawn Ticket with her name on it. Her sister and her daughter confirmed her identity. " +
                "She was found by Constable Watkins on his Patrol at around 1:35-1:45 am.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "I was on Patrol as i said. I came into Mitre-square at 1.44, when I discovered the body lying on the right as I entered the square. " +
                "The woman was on her back, with her feet towards the square. Her clothes were thrown up. I saw her throat was cut and the stomach ripped open. " +
                "She was lying in a pool of blood. I did not touch the body";
            hints[4].SetActive(true);
            hints[1].SetActive(true);
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "I was on duty in Goulston-street, Whitechapel, on Sunday morning, Sept. 30. I heard of the murder of a woman in Mitre Square and went there.";
        }
    }
    public void clicked_Map()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            map1 = true;
            Next.SetActive(true);
            Map.GetComponent<Image>().sprite = bar;
            Text.GetComponent<Text>().text = "On Sunday around half past eight, the victim was found drunk in front of the Bull In Pub at 25 Aldgate High Street. " +
                "";
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Map.GetComponent<Image>().sprite = route_watkins;
            Text.GetComponent<Text>().text = "This is my route. It takes about 15 Minutes to finish one circle. I checked Mitre Square at around 1:30 am. " +
                "I had my lantern alight and on, looked at corners and passages. There was no one there, no people, no body. She was not there when I passed. " +
                "One circle later, at around 1:45, I discovered her, lying in a pool of her blood.";
            hints[4].SetActive(true);
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "Before I left for the crime scene I was about here, where I found a piece of cloth, drenched in blood. " +
                "It looked like someone wiped his hands with it. The murder must have placed it there. It was lying under a grafitto.";
            Map.GetComponent<Image>().sprite = graffito;
            hints[5].SetActive(true);
        }
    }
    public void clicked_Warren()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "Yes, I ordered to have it cleaned up. There are already antisemitism movements and I didn't want the situation to escalate." +
                "I had Long made a copy of the graffitto.";
            hints[3].SetActive(true);
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "Warren is the head of London Metropolitan Police. Whatever he says, in the end, his word counts.";
            hints[4].SetActive(true);
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "There was a discussion between the Metropolitan Police and the Constables. While the PCs wanted to keep the graffitto as a possible crucial piece of evidence, " +
                "Warren wanted it gone.";
        }
    }
    public void clicked_Long()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "Long was the one who found a piece of cloth that turned out as a piece of the victims apron.This means that the murderer must have placed it there," +
                "either by chance or willingly.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "Long is a fellow Constable who was on Patrol that night, but on Goulston Street.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "I made a draft of the graffitto. It bascially said: The Juwes are the men that will not be blamed for nothing. I didn't mind it on my patrol, but I did when I " +
                "found the cloth at around 2:55 am. I passed the exact same spot on 2:20 am together with a fellow PC, but it was not there then.";
        }
    }
    public void clicked_Blood()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "She hat multiple wounds, but the most interesting, was the part of the ear that was found on top of her, like that letter said. Also, the way the organs were removed cleanly, " +
                "the doctors suspect that the murderer must have some konwledge, possibly by cutting up animals. Maybe a butcher?";
            hints[6].SetActive(true);
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "She lay on her back, head turned, both palms upward. The clothes were thrown up and the upper part of the dress was torn. Her face looked mutilated and " +
                "the uterus was cut away with the exception of a small portion, and the left kidney was also cut out. Both these organs were absent, and have not been found.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "The body was mutilated, i heard from Dr Brown. The face was very much mutilated, the eyelids, the nose, the jaw, the cheeks, the lips, and the mouth all bore cuts. " +
                "There were abrasions under the left ear. The throat was cut across to the extent of six or seven inches.";
        }
    }
    public void clicked_Jews()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "I it was washed away to prevent more antisemitism, and I still think its the right choice.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "I heard about this graffito. Apparently it was washed away on orders. I never saw it though.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "The graffito is not there anymore. Warren had it washed away";
            hints[2].SetActive(true);
        }
    }
    public void clicked_Letter()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "Yes, we received a letter from someone calling himself Jack the Ripper. I will send it to you later. However, In the letter he promised to " +
                "cut off the ear of his next witness. I wonder if the other murder that happened the same night has anything to do with it, as she wasn't missing any body parts.";
            hints[7].SetActive(true);
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "I dont know anything about a letter.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "I dont know anything about a letter.";
        }
    }
    public void clicked_Stride()
    {
        if (Police.GetComponent<PoliceQuestioning>().war == true)
        {
            Text.GetComponent<Text>().text = "As I heard, the other victim barely had any wounds. Merely a cut throat. Is this even the doing of the same man?";
        }
        else if (Police.GetComponent<PoliceQuestioning>().wat == true)
        {
            Text.GetComponent<Text>().text = "It takes about 20 minutes from Dutfields Yard to Mitre Square. It would have been completely doable to do both murders.";
        }
        else if (Police.GetComponent<PoliceQuestioning>().lon == true)
        {
            Text.GetComponent<Text>().text = "It took me 10 minutes from Goulston Street to Mitre Square. But he couldn't have been there at 2:20 when i passed. So what did he do between the killing and the placing of the cloth?";
        }
    }
    #endregion

    //Handels warrens map interaction
    public void Foward()
    {
        if (map1)
        {
            Map.GetComponent<Image>().sprite = station;
            map2 = true;
            map1 = false;
            Text.GetComponent<Text>().text = "She was escorted to the Bishopsgate Police Station to sober up in a cell until at around 1 am.";
        }
        else if (map2)
        {
            Map.GetComponent<Image>().sprite = club;
            map3 = true;
            map2 = false;
            Text.GetComponent<Text>().text = "She left, saying she would go visit her sister, but apparently she went left to drink on, crossing the Imperial Club on 16-17 Duke Street, " +
                "where she was seen with another men by three men in front of the club at around 1:35, shortly after watkins left Mitre Square.";
        }
        else if (map3)
        {
            Map.GetComponent<Image>().sprite = mitre;
            map4 = true;
            map3 = false;
            Text.GetComponent<Text>().text = "They saw the couple leave, heading to Mitre Square. Where she was eventually found.";
        }
        else if (map4)
        {
            Map.GetComponent<Image>().sprite = bar;
            map1 = true;
            map4 = false;
            Text.GetComponent<Text>().text = "On Sunday around half past eight, the victim was found drunk in front of the Bull In Pub at 25 Aldgate High Street. " +
            "";
        }

    }

    //Close current questioning and return to Constable chosing screen
    public void Close()
    {
        Next.SetActive(false);
        Police.GetComponent<PoliceQuestioning>().wat = false;
        Police.GetComponent<PoliceQuestioning>().war = false;
        Police.GetComponent<PoliceQuestioning>().lon = false;

        Police.GetComponent<PoliceQuestioning>().panel_Constables.SetActive(true);
        Police.GetComponent<PoliceQuestioning>().panel_Questioning.SetActive(false);
    }
}
