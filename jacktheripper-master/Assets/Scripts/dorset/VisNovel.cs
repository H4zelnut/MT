using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dorset Street Story Reconstruction
//Visual Novel Type Style
public class VisNovel : MonoBehaviour
{
    //Events in Story Reconstruction
    //has time string, story string, and picture of event
    struct Event {
        public string time;
        public string story;
        public GameObject picture;

        public Event(string time, string story, GameObject picture)
        {
            this.time = time;
            this.story = story;
            this.picture = picture;
        }
    }

    public GameObject Dorset, McCarthy, Bowyer1, Bowyer2, Paper1, Paper2, Paper3, Paper4, Inside, Hounds; //Gameobjects per Story Event
    public Text Time,           //for Event.time
                Description;    //for Event.story
    private int index;          //current Eventindex
    private List<Event> plot;   //whole story
    bool asked;                 //for skipping AR Logic Quiz

    public GameObject Up, Down, Quiz, Procede, Question, Question2;

    void Start()
    {
        index = 0;
        plot = new List<Event>();
        SetStory();
        asked = false;  // needed for Questioning: Do you want to skip
        Time.text = plot[0].time;
        Description.text = plot[0].story;
        plot[0].picture.SetActive(true);
    }

    // Update Story fields
    void Update()
    {
        Time.text = plot[index].time;
        Description.text = plot[index].story;
    }

    //Continue in the story
    //checks for story event index and catches unique index events
    public void Next()
    {
        if (index == 4 && !asked)
        {
            Up.SetActive(false);
            Down.SetActive(false);
            Quiz.SetActive(true);
            asked = true;
        }
        else if (index == 4 && asked)
        {
            Question.SetActive(true);
        }
        else if(index == 9)
        {
            Question2.SetActive(true);
            Up.SetActive(false);
            Down.SetActive(false);
        }
        else
        {
            plot[index].picture.SetActive(false);
            index += 1;
            plot[index].picture.SetActive(true);
        }
    }

    //Called when AR Logic Puzzle is skipped bc finished or ... skipped :D
    //Change layout back to story style
    public void Yes()
    {
        plot[index].picture.SetActive(false);
        index += 1;
        plot[index].picture.SetActive(true);
        Up.SetActive(true);
        Down.SetActive(true);
        Quiz.SetActive(false);
        Question.SetActive(false);
    }
    //Hardcoded Story 
    //Every time Event has a Plot object (time and story string, picture)
    private void SetStory()
    {
        string time;
        string story;
        GameObject picture;

        time = "10:45 AM";
        story = "John (aka Jack) McCarthy, owner of 'McCarthy's Rents' and landlord of Millers Court persuades his accounting books. He cannot overlook the fact that his tenant, " +
            "Mary Jane Kelly, was six months behind in her rent. Until now, he had allowed the fees to accumulate, but it was time to see if Kelly could pay up. He send his assistant," +
            "Thomas Bowyer, to catch Kelly before she leaves her room for the day.";
        picture = McCarthy;
        plot.Add(new Event(time, story, picture)); //0

        time = "10:50 AM";
        story = "Thomas Bowyer (aka 'Inidan Harry') makes his way to Millers Court. Upon arriving, he knockes on the door twice. Receiving no answer, he rounds the corner of the yard " +
            "to see that a couple of glass windowpanes are broken. He reaches to the knocked-out glass and moved the curtain to see whether Mary Kelly was home or not. ";
        picture = Bowyer1;
        plot.Add(new Event(time, story, picture)); //1

        time = "10:50 AM";
        story = "The first thing he recognizes looks like lumps of meat sitting on the bedside table. " +
            "Taking a closer look, the second thing he sees sends him running back to McCarthy's office. ";
        picture = Bowyer2;
        plot.Add(new Event(time, story, picture)); //2

        time = "10:55 AM";
        story = "Upon the return of his assistant, McCarthy follows Bowyer back to Millers Court. He draws back the curtain and sees the same " +
            "scene as Bowyer did before. In horror, he sends Bowyer to find a constable.";
        picture = Paper1;
        plot.Add(new Event(time, story, picture)); //3

        time = "11:00 AM";
        story = "Bowyer runs to the Commercial Street Police Station where he finds Inspector Walter Beck and Detective Walter Dew. He arrives out of breath and in shock. " +
            "He can barely get any words out of his mouth but he manages to mumble: 'Another one. Jack the Ripper. Awful. Jack McCarthy sent me.' The policemen hurry " +
            "to Millers Court. Help them find the right room!";
        picture = Paper1;
        plot.Add(new Event(time, story, picture)); //4

        // Insert Quiz > UP and Down deactive > Quiz active > next deactive.

        time = "11:05 AM";
        story = "When the officers find Mary Kellys room they observe the carnage through the broken window with horror. They send for Inspector Abberline who is in charge of the " +
            "Ripper Case.";
        picture = Paper2;
        plot.Add(new Event(time, story, picture)); //5

        time = "11:30 AM";
        story = "Abberline and Doctor George Baxter Phillips, the police surgeon, arrive at the crime scene. The door to the small room is locked and instead of breaking it in, Abberline " +
            "orders to wait for the arrival of two Bloodhounds. Using dogs to sniff out murderers is a new and untested technique but Scotland Yard is eager to show the public that they " +
            "are taking the murders seriously.";
        picture = Hounds;
        plot.Add(new Event(time, story, picture)); //6

        time = "01:30 PM";
        story = "The dogs do not arrive soon. Their owner, Edwin Brough, had reclaimed his dogs two weeks prior, when it became clear that Scotland Yard would neither pay " +
            "nor insure him for their services. Inspector Abberline does not know this and so he waits two hours for them to come. In the mean time, he can only block " +
            "off Millers Court to pedestrians and wait.";
        picture = Paper2;
        plot.Add(new Event(time, story, picture)); //7

        time = "01:30 PM";
        story = "Eventually, Superintendent Arnold arrives and orders the door to be broken down. John McCarthy has to use a pickaxe to chop the front door down. ";
        picture = Paper4;
        plot.Add(new Event(time, story, picture)); //8

        time = "01:30 PM";
        story = "The scene inside will haunt them forever.";
        picture = Inside;
        plot.Add(new Event(time, story, picture)); //9

    }
}
