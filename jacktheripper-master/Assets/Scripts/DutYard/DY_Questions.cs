using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Questioning of DY witnesses
public class DY_Questions : MonoBehaviour
{
    //Every Person with name and set of answers
    struct Person
    {
        public string Name;
        public List<Answer> answers;

        public Person(string name, List<Answer> answers)
        {
            Name = name;
            this.answers = answers;
        }
    }
    //Every answer has a question, answer and index
    struct Answer
    {
        public string question;
        public string answer;
        public int idx;

        public Answer(string question, string answer, int idx)
        {
            this.question = question;
            this.answer = answer;
            this.idx = idx;
        }
    }
    private List<int> hints;
    private List<Person> persons;
    private bool manPassed, slit, alertedPC, pack, club, man1, man2, time; // Clues to press witness
    private List<string> answer; 

    private List<bool> wits;
    string currWit;

    public Sprite dy_Normal, dy_Mortimer, dy_Smith, dy_Schwartz1, dy_Schwartz2, dy_Schwartz3, dy_Schwartz4, dy_Club; //sprites for clues

    public GameObject witName, text, drag, map, next, prev;
    public InputField nameField;
    public Text requested;
    private bool gold, lam, marsh, smi, black, phil;
    public GameObject G, L, M, S, D; //Witnesses
    private int temp = 1;

    
    void Start()
    {
        hints = new List<int>();
        persons = new List<Person>();
        //manPassed = slit = alertedPC = pack = club = man1 = man2 = time = false;
        #region hints.Add(...)
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        hints.Add(0);
        #endregion
        wits = new List<bool>();
        #region wits.Add(...)
        wits.Add(false);
        wits.Add(false);
        wits.Add(false);
        wits.Add(false);
        wits.Add(false);
        wits.Add(false);
        wits.Add(false);
        wits.Add(false);
        for(int i = 0; i<wits.Count; i++)
        {
            wits[i] = false;
        }
        #endregion
        persons.Add(new Person("Diemschutz", SetDiemschutz()));
        persons.Add(new Person("Smith", SetSmith()));
        persons.Add(new Person("Lamb", SetLamb()));
        persons.Add(new Person("Doctors", SetDoctors()));
        persons.Add(new Person("Schwarz", SetSchwartz()));
        persons.Add(new Person("Marshall", SetMarshall()));
        persons.Add(new Person("Mortimer", SetMortimer()));
        persons.Add(new Person("Goldstein", SetGoldstein()));
        currWit = "dummy";
        text.GetComponent<Text>().text = "...";
        gold= lam= marsh= smi= black= phil = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetNewHints();

        //Check for Schwartzes Animation
        if (wits[4] == true && hints[6] > 0)
        {
            next.SetActive(true);
            prev.SetActive(true);
        }
        else
        {
            next.SetActive(false);
            prev.SetActive(false);
        }
    }
    void GetNewHints()
    {
        //Check if new Hints discovered
        for (int i = 0; i < hints.Count; i++)
        {
            if (hints[i] > 0)
            {
                drag.GetComponent<DragnDrop>().hinties[i].SetActive(true);
            }
        }
    }
    
    
    /*  0   Man passed          Mortimer > Goldstein
     *  1   Slit Throat         Nothing more > Doctors + PCs, ...
     *  2   Alerted PC          Diemschutz > PC Lamb und Collins
     *  3   pack              Doctors > Diemschutz/Mortimer > Packer
     *  4   Club House          
     *  5   1st Man             Schwartz > Schwartz+ 2nd
     *  6   2nd Man             Schwarz > Schwartz
     *  7   Time                When (Iwie alle)
     *  8   Board School        Map 
     *  9   Dark                Diemschutz > Marshall? /Schwartz/ Mortimer
     *  10  0+7                 
    */
    
    //called when User wants to ask witness
    //checks if Option1 is set > calls Answering
    public void Check()
    {
        string tmp1, tmp2 = "";
        for (int i = 0; i < wits.Count; i++)
        {
            if (wits[i] == true)
            {
                currWit = persons[i].Name;
            }
        }
        
        if (drag.GetComponent<DragnDrop>().o1 && drag.GetComponent<DragnDrop>().o2)
        {
            tmp1 = drag.GetComponent<DragnDrop>().name1;
            tmp2 = drag.GetComponent<DragnDrop>().name2;
        }
        else if (drag.GetComponent<DragnDrop>().o1 || GetComponent<DragnDrop>().o2)
        {
            if (drag.GetComponent<DragnDrop>().o1)
            {
                tmp1 = drag.GetComponent<DragnDrop>().name1;
                Answering1(tmp1);
            }
            else if (drag.GetComponent<DragnDrop>().o2)
            {
                tmp2 = drag.GetComponent<DragnDrop>().name2;
                Answering1(tmp2);
            }
        }
    }
    
    //Called when pressed
    //check which was 
    private void Answering1(string o)
    {
        switch (currWit)
        {
            case "Diemschutz":
                temp = 0;
                break;
            case "Smith":
                temp = 1;
                break;
            case "Lamb":
                temp = 2;
                break;
            case "Doctors":
                temp = 3;
                break;
            case "Schwarz":
                temp = 4;
                break;
            case "Marshall":
                temp = 5;
                break;
            case "Mortimer":
                temp = 6;
                break;
            case "Goldstein":
                temp = 7;
                break;
        }
        text.GetComponent<Text>().text = persons[temp].answers.Find(x => x.question == o).answer;
        if (persons[temp].answers.Find(x => x.question == o).idx != -1)
        {
            hints[persons[temp].answers.Find(x => x.question == o).idx] = 1;
        }
    }

    // Request new names
    // Check for multiple versions of different names to accept
    public void Names()
    {
        string name = nameField.text;
        if(name == "Mr Goldstein" || name == "Mr. Goldstein" || name == "mr Goldstein" || name == "mr. Goldstein" || name == "Mr goldstein" || name == "Mr. goldstein"|| name == "mr goldstein" || name == "mr. goldstein" || name == "Goldstein" || name == "goldstein")
        {
            if (gold == false) {
                requested.text += "\nMr Goldstein";
                gold = true;
                G.SetActive(true);
            }
        }
        else if (name == "Mr Marshall" || name == "Mr. Marschall" || name == "mr Marshall" || name == "mr. Marshall" || name == "Mr marshall" || name == "Mr. marshall" || name == "mr marshall" || name == "mr. marshall" || name == "Marshall" || name == "marshall")
        {
            if (marsh == false)
            {
                requested.text += "\nMr. Marshall";
                marsh = true;
                M.SetActive(true);
            }
        }
        else if (name == "Mr Smith" || name == "Mr. Smith" || name == "mr Smith" || name == "mr. Smith" || name == "Mr smith" || name == "Mr. smith" || name == "mr smith" || name == "mr. smith" || name == "Smith" || name == "smith"
            || name == "PC Smith" || name == "PC. Smith" || name == "pc Smith" || name == "pc. Smith" || name == "PC smith" || name == "PC. smith" || name == "pc smith" || name == "pc. smith")
        {
            if (smi == false)
            {
                requested.text += "\nPC Smith";
                smi = true;
                S.SetActive(true);
            }
        }
        else if (name == "Mr Lamb" || name == "Mr. Lamb" || name == "mr Lamb" || name == "mr. Lamb" || name == "Mr lamb" || name == "Mr. lamb" || name == "mr lamb" || name == "mr. lamb" || name == "Lamb" || name == "lamb"
            || name == "PC Lamb" || name == "PC. Lamb" || name == "pc Lamb" || name == "pc. Lamb" || name == "PC lamb" || name == "PC. lamb" || name == "pc lamb" || name == "pc. lamb")
        {
            if (lam == false)
            {
                requested.text += "\nPC Lamb";
                lam = true;
                L.SetActive(true);
            }
        }
        else if (name == "Mr Blackwell" || name == "Mr. Blackwell" || name == "mr Blackwell" || name == "mr. Blackwell" || name == "Mr blackwell" || name == "Mr. blackwell" || name == "mr blackwell" || name == "mr. blackwell" || name == "Blackwell" || name == "blackwell"
            || name == "Dr Blackwell" || name == "Dr. Blackwell" || name == "dr Blackwell" || name == "dr. Blackwell" || name == "Dr blackwell" || name == "Dr. blackwell" || name == "dr blackwell" || name == "dr. blackwell"
            || name == "Mr Phillips" || name == "Mr. Phillips" || name == "mr Phillips" || name == "mr. Phillips" || name == "Mr phillips" || name == "Mr. phillips" || name == "mr phillips" || name == "mr. phillips" || name == "Phillips" || name == "phillips"
            || name == "Dr Phillips" || name == "Dr. Phillips" || name == "dr Phillips" || name == "dr. Phillips" || name == "Dr phillips" || name == "Dr. phillips" || name == "dr phillips" || name == "dr. phillips")
        {
            if (black == false || phil == false)
            {
                requested.text += "\nDr. Blackwell and Dr. Phillips";
                black = true;
                phil = true;
                D.SetActive(true);
            }
        }
      
        nameField.text = "";
    }

    //Close Pressing Panel > set all "current witnesses" to false
    public void Close()
    {
        for(int i = 0; i<wits.Count; i++){
            wits[i] = false;
        }
    }

    //prepare page when new person is called:
    #region klicked persons
    public void Diemschutz()
    {
        text.GetComponent<Text>().text = "I reside at No. 40 Berner-street. " +
            "On Saturday I left home in the morning, and returned on Sunday morning. " +
            "I noticed the time at the baker's shop at the corner of Berner-street. I drove into the yard, both gates being wide open. It was rather dark there. All at once my pony shied at some object on the right. " +
            "I looked to see what the object was, and observed that there was something unusual, but could not tell what. It was a dark object. " +
            "I jumped down from my barrow to see that there was some figure there. " +
            "I could tell from the dress that it was the figure of a woman.";
        wits[0] = true;
        drag.GetComponent<DragnDrop>().hinties[7].SetActive(true); //time 
        drag.GetComponent<DragnDrop>().hinties[9].SetActive(true); //dark
        witName.GetComponent<Text>().text = "Mr. Diemschutz";
        map.GetComponent<Image>().sprite = dy_Club;

        currWit = "Diemschutz";
    }
    public void Smith()
    {
        text.GetComponent<Text>().text = "On Saturday last I went on duty at ten p.m.My beat was past Berner - street, and would take me twenty - five minutes or half an hour to go round, passing the board school. " +
            "I was in Berner - street about half-past twelve or twenty - five minutes to one o'clock, and having gone round my beat, was at the Commercial-road corner of Berner-street again at one o'clock. " +
            "I was not called. I saw a crowd outside the gates of No. 40, Berner - street. I heard no cries of 'Police.' When I came to the spot two constables had already arrived. " +
            "The gates at the side of the club were not then closed. I do not remember that I passed any person on my way down. I saw that the woman was dead, and I went to the police-station for the ambulance, " +
            "leaving the other constables in charge of the body. Dr.Blackwell's assistant arrived just as I was going away.";
        drag.GetComponent<DragnDrop>().hinties[8].SetActive(true); //board school
        wits[1] = true;
        witName.GetComponent<Text>().text = "PC. Smith";
        map.GetComponent<Image>().sprite = dy_Smith;

        currWit = "Smith";
    }
    public void Lamb()
    {
        text.GetComponent<Text>().text = "I was on duty in Commercial-road, between Christian-street and Batty-street, when two men came running towards me and shouting. " +
            "I went to meet them, and they called out, 'Come on, there has been another murder.' " +
            "I asked where, and as they got to the corner of Berner-street they pointed down and said, 'There.' " +
            "Arriving at the gateway of No. 40 I observed something dark lying on the ground on the right-hand side. I turned my light on, when I found that the object was a woman, with her throat cut and apparently dead. " +
            "I sent the other constable for the nearest doctor, and a young man who was standing by I despatched to the police station to inform the inspector what had occurred.";
        wits[2] = true;
        witName.GetComponent<Text>().text = "PC. Lamb";
        map.GetComponent<Image>().sprite = dy_Normal;

        currWit = "Lamb";
    }
    public void Doctors()
    {
        text.GetComponent<Text>().text = "On Sunday morning last, at ten minutes past one o'clock, I was called to Berner-street by a policeman. I consulted my watch on my arrival, and it was 1.16 a.m. Dr Phillips arrived shortly after. " +
            "The deceased was lying on her left side obliquely across the passage, her face looking towards the right wall. " +
            "Her legs were drawn up, her feet close against the wall of the right side of the passage. Her head was resting beyond the carriage-wheel rut, the neck lying over the rut. " +
            "Her feet were three yards from the gateway. Her dress was unfastened at the neck. The neck and chest were quite warm, as were also the legs, and the face was slightly warm. " +
            "The hands were cold. The right hand was open and on the chest, and was smeared with blood. The left hand, lying on the ground, was partially closed, and contained a small packet of cachous wrapped in tissue paper." +
            "Some of the cachous were scattered about the yard. It must have gone very fast.";
        wits[3] = true;
        witName.GetComponent<Text>().text = "Dr. Blackwell & Dr. Phillips";
        map.GetComponent<Image>().sprite = dy_Normal;

        currWit = "Doctors";
    }
    public void Schwartz()
    {
        text.GetComponent<Text>().text = "My name is Israel Schwartz, I am from Hungary and I think I might have seen the victim. I turned into Berner Street when I noticed a man walking ahead of me. " +
            "He stopped to talk to a woman who was standing in the gateway of Dutfield’s Yard. I am emphatic that the woman had seen was the victim. " +
            "The man tried to pull the woman into the street, but then spun her around, and threw her onto the footway, whereupon the woman screamed three times, but not very loudly.";
        wits[4] = true;
        witName.GetComponent<Text>().text = "Mr. Schwartz";
        map.GetComponent<Image>().sprite = dy_Schwartz1;

        currWit = "Schwarz"; ;
    }
    public void Marshall()
    {
        text.GetComponent<Text>().text = "I reside at No. 64, Berner-street, and am a labourer at an indigo warehouse. I have seen the body at the mortuary. I saw the deceased on Saturday night last." +
            "In our street, three doors from my house. She was on the pavement, opposite No. 58, between Fairclough-street and Boyd-street. She talked to a man";
        wits[5] = true;
        witName.GetComponent<Text>().text = "Mr. Marshall";
        map.GetComponent<Image>().sprite = dy_Normal;

        currWit = "Marshall";
    }
    public void Goldstein()
    {
        text.GetComponent<Text>().text = "It was me Mrs Mortimer saw...";
        wits[7] = true;
        witName.GetComponent<Text>().text = "Mr. Goldstein";
        map.GetComponent<Image>().sprite = dy_Normal;

        currWit = "Goldstein";
    }
    public void Mortimer()
    {
        text.GetComponent<Text>().text = "I saw this man pass...";
        drag.GetComponent<DragnDrop>().hinties[0].SetActive(true); //Man passed
        drag.GetComponent<DragnDrop>().hinties[1].SetActive(true); //slit throat
        wits[6] = true;
        witName.GetComponent<Text>().text = "Mrs. Mortimer";
        map.GetComponent<Image>().sprite = dy_Mortimer;
        currWit = "Mortimer";
    }
    #endregion
    
    //Hardcode Answers per Witness
    #region Set Witness Statements
    private List<Answer> SetMortimer()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "Yes, I heard the measured, heavy stamp of a policeman, passing the house on his daily beat, so I went outside to look. I saw someone pass, I think it must have been Mr Goldstein." +
            "He was carrying a suspicious black package. Then I went back inside and bolted the door.";
        Answer A = new Answer(q, a, 3);
        answers.Add(A);

        q = "Slit Throat";
        a = "I haven't seen her. I heard the commotion but I thought it was coming from a row by the Club.";
        A = new Answer(q, a, 4);
        answers.Add(A);

        q = "Alerted PC";
        a = "I didnt alert anyone.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "It was black and long and he was carrying it under his arm, sheltering it.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "The Club house is two doors further down if you face Fairclough street. There was a meeting of some sort";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "I saw a couple pass. I think the woman was the victim. I don't know who the man was, is this the person you are looking for?";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "2nd\nMan";
        a = "What second Man? I only saw a couple and Mr Goldstein";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "I heard some steps at about 0:50 AM. I didn't leave the house later";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is on the other side of Berner street, on the corner to Fairclough Street.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "Yes, it was late, it was dark. So?";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "manpassed + time";
        a = "Mr Goldstein passed at about 0:50 AM to 0:55 AM.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetDiemschutz()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "I didn't see anyone pass. I went into the club and asked where my wife was. I found her in the front room on the ground floor. " +
            "There were several members in the front room of the club, and I told them all that there was a woman lying in the yard, though I could not say whether she was drunk or dead.";
        Answer A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Slit Throat";
        a = "I did not disturb the body.  I ran off at once for the police. I could not find a constable in the direction which I took, so I shouted out 'Police' as loudly as I could. " +
            "A man whom I met in Grove- street returned with me, and when we reached the yard he took hold of the head of the deceased. As he lifted it up I saw the wound in the throat. " +
            "At the very same moment an Alerted PC arrived.";
        A = new Answer(q, a, 2);
        answers.Add(A);

        q = "Alerted PC";
        a = "If I remember correctly his name was PC Lamb. There was also a PC Smith.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "I don't know about Packs";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "Yes its the International Workmen's Club. I am a steward there. I am married, and my wife assists in the management there. ";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "I didn't see anyone pass before I informed the men at the club. While some ran for the police, some stayed with it.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "2nd\nMan";
        a = "I didn't see anyone there, besides the club members I informed.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "On Saturday I left home about half-past eleven in the morning, and returned exactly at one o'clock on Sunday morning. " +
            "I noticed the time at the baker's shop at the corner of Berner-street, so I am pretty sure I found her at one o'clock.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is on the other side of Berner street, on the corner to Fairclough Street.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "As I jumped down from my barrow and struck a match. It was rather windy, and I could only get sufficient light to see that there was some figure there. I could tell from the dress that it was the figure of a woman." +
            "When I returned with the members of the club, I brought a candle and noticed the blood.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetSchwartz()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "Yes I saw him, I believed it was a domestic attack. You must know that I have a criminal record, but I have been released and innocent since. This was only the first man I saw.";
        Answer A = new Answer(q, a, 5);
        answers.Add(A);

        q = "Slit Throat";
        a = "I did not see the victim, I left when she was still alive.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Alerted PC";
        a = "I did not alert anyone. I was cautious as I tried to keep away from such situations.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "I don't know about Packs";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "There is supposed to be one at the end of the street. I don't know anything about it.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "Yes, the man who threw the victim to the ground. He  was about 5 feet, 5 inches tall, aged around 30 with dark hair, a fair complexion, " +
            "a small brown moustache. He had a full face, broad shoulders and appeared to be slightly intoxicated. I crossed the street when I saw him. That's when I saw a second man lighting his pipe." +
            "He stood at the other side to which I crossed. When I passed him, the first man shouted to the second the word 'Lipski'. You see, I am jewish and they use it as an insult.";
        A = new Answer(q, a, 6);
        answers.Add(A);

        q = "2nd\nMan";
        a = "This second man was aged about 35, around 5 feet, 11 inches tall, had a fresh complexion, light brown hair, a brown moustache, and wore a dark overcoat with an old, black, hard felt hat. " +
            "I panicked and began to run. I managed to lose them by the time I reached the nearby arch. Maybe they didn't even follow me I didn't look back, didn#t go back.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "I turned into Berner Street at around 12:45. Then I saw the woman with the man. She was alive then.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "I don't know about a Board School";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "It was dark then, yes. I saw the victim though. I am not completely sure it was her, but there was no body there either. I dont know their names.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetSmith()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "I did notice a couple, the woman was probably the victim, I feel certain.";
        Answer A = new Answer(q, a, 0);
        answers.Add(A);

        q = "Slit Throat";
        a = "When I arrived, Doctor Blackwell and Doctor Phillips were already there, examining the body. So i left.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Alerted PC";
        a = "A Collegue, PC Lamb was on the scene as well, yes.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "Pack? I didn't see any.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "There is a Club House on my route, at the end of the street.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "He had a parcel wrapped in a newspaper in his hand. The parcel was about 18in. long and 6in. to 8in. broad. He was about 5ft. 7in. He wore a dark felt deerstalker's hat, his clothes were also dark. The coat was a cutaway coat." +
            "I did not notice him much. I should say he was twenty-eight years of age and of respectable appearance. I did not overhear any conversations.";
        A = new Answer(q, a, 0);
        answers.Add(A);

        q = "2nd\nMan";
        a = "I did not see any second man.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "I was in Berner - street about half-past twelve or twenty - five minutes to one o'clock, and having gone round my beat, was at the Commercial-road corner of Berner-street again at one o'clock.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is across Dutfields Yard, where the body was found";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "It was after Midnight so it was dark.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetLamb()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "I was called when the murder had already occured. I did not see anyone before.";
        Answer A = new Answer(q, a, 0);
        answers.Add(A);

        q = "Slit Throat";
        a = "It was cut completely. I checked the pulse, the hand was warm, but she was dead and there was no blood on the hand. Also none in the club itself or on any of the crowd that was gathering. " +
            "The victim was lying on her left side, with her left hand on the ground.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Alerted PC";
        a = "A Collegue, PC Smith was on the scene as well, yes.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "Pack? I didn't see any.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "I don't know about a club house";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "There were multiple men in the crowd.";
        A = new Answer(q, a, 0);
        answers.Add(A);

        q = "2nd\nMan";
        a = "There were multiple men in the crowd.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "I am not on the Berner-street beat, but I passed the end of the street in Commercial-road six or seven minutes before";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is across Dutfields Yard, where the body was found";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "It was rather dark, but I think there was light enough, though a possible murderer would be somewhat indistinct from Commercial-road.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetDoctors()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "I was called when the murder had already occured. I did not see anyone before.";
        Answer A = new Answer(q, a, 0);
        answers.Add(A);

        q = "Slit Throat";
        a = "The incision in the neck commenced on the left side, 2 inches below the angle of the jaw, and almost in a direct line with it, nearly severing the vessels on that side, " +
            "cutting the windpipe completely in two, and terminating on the opposite side 1 inch below the angle of the right jaw, but without severing the vessels on that side. " +
            "A stream of blood ran until the back door of the club, but on prints were found in it.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Alerted PC";
        a = "Multiple Policemen occured, a Smith, a Lamb and more.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "Pack? I didn't see any.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "The murder scene is apparently the back yard of the club house. The blood of the victim flowed in a stream to the back door, but all club members were searched thoroughly, none hat blood on their shoes." +
            "In my opinion, it is not possible for the murderer to be bloodless.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "There were multiple men in the crowd.";
        A = new Answer(q, a, 0);
        answers.Add(A);

        q = "2nd\nMan";
        a = "There were multiple men in the crowd.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "I was ordered at around 10 Minutes after one o'clock. Dr. Phillips arrived shortly after. By the time, around 30 club members were present and watching the body.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is across Dutfields Yard, where the body was found";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "It was rather dark, but I saw the bonnet of the deceased that was lying on the ground a few inches from the head. Her dress was unbuttoned at the top.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetMarshall()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "I saw the victim with a man, they were kissing. I heard him say: 'You would say anything but your prayers.' he was mild speaking, sounded like an educated man, they went after that.";
        Answer A = new Answer(q, a, 0);
        answers.Add(A);

        q = "Slit Throat";
        a = "Gladly, I didn't take a look at her.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Alerted PC";
        a = "I didn't leave afterwards. I didn't see Policemen.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "Pack? I didn't see any.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "The Club House was lit, they had a meeting that night.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "There was no gas-lamp near. The nearest was at the corner, about twenty feet off. I did not see the face of the man distinctly. He was dressed in a black cut-away coat and dark trousers." +
            "About his age, Middle-aged he seemed to be. He wore a cap, a round cap with a small peak, something like a sailor would wear. He must have been around 5ft. 6in. and rather stout. " +
            "I should say he was in business, and did nothing like hard work.";
        A = new Answer(q, a, 0);
        answers.Add(A);

        q = "2nd\nMan";
        a = "I didn't see any second man.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "I went outside about quarter to twele o'clock. I watched them and went back inside about twelve o'clock. Maybe a bit earlier. I did not hear anything after that.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is across Dutfields Yard.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "There is a gas lamp at the corner of Boyd-street but thats rather far. Too far to have seen his face.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    private List<Answer> SetGoldstein()
    {
        List<Answer> answers = new List<Answer>();

        string q = "Man Passed";
        string a = "I am the person Mrs. Mortimer saw, yes. I walked down berner street that night and passed the Club House. I had been returning home from a coffee shop in Spectacle Alley, Whitechapel.";
        Answer A = new Answer(q, a, 0);
        answers.Add(A);

        q = "Slit Throat";
        a = "I just passed and didn't see anything.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Alerted PC";
        a = "I saw a Policeman on my way, I was told it is Mr. Marshall.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Pack";
        a = "Yes, I carried a black Package, but it contained nothing. It was an empty cigarette box. I gave them to the police.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Club House";
        a = "I looked inside the window on my way past the Club House, there was still light.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "1st\nMan";
        a = "I didn't see anyone besides the Police officer.";
        A = new Answer(q, a, 0);
        answers.Add(A);

        q = "2nd\nMan";
        a = "I didn't see anyone besides the Police officer.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Time";
        a = "It must have been 10 Minutes before twelve o'clock.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Board School";
        a = "The Board School is across Dutfields Yard.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        q = "Dark";
        a = "It was quite dark. I suppose the package must have looked suspicious, but there was nothing inside.";
        A = new Answer(q, a, -1);
        answers.Add(A);

        return answers;
    }
    #endregion

    //Schwartzes Animation Map 
    //Called when clicked next on Map
    public void Next()
    {
        if(map.GetComponent<Image>().sprite == dy_Schwartz1)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz2;
        }
        else if (map.GetComponent<Image>().sprite == dy_Schwartz2)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz3;
        }
        else if (map.GetComponent<Image>().sprite == dy_Schwartz3)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz4;
        }
        else if (map.GetComponent<Image>().sprite == dy_Schwartz4)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz1;
        }
    }
    //Called when clicked prev on Map
    public void Prev()
    {
        if (map.GetComponent<Image>().sprite == dy_Schwartz1)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz4;
        }
        else if (map.GetComponent<Image>().sprite == dy_Schwartz2)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz1;
        }
        else if (map.GetComponent<Image>().sprite == dy_Schwartz3)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz2;
        }
        else if (map.GetComponent<Image>().sprite == dy_Schwartz4)
        {
            map.GetComponent<Image>().sprite = dy_Schwartz3;
        }
    }
}
