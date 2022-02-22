using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Interrogation Days of Mitre Square / Dorset Street Case
// Witnesses are interrogated by chosing Questions to ask them
public class Dialogue : MonoBehaviour
{
    // Witness Dialogues Interrogations
    [SerializeField]
    List<DialogueQuest>
        optionsDavies = new List<DialogueQuest>(),
        optionsDonovan = new List<DialogueQuest>(),
        optionsRichardson = new List<DialogueQuest>(),
        optionsSmith = new List<DialogueQuest>(),
        optionsBaxter = new List<DialogueQuest>(),
        optionsPizer = new List<DialogueQuest>(),
        optionsChandler = new List<DialogueQuest>();
    
    public GameObject 
        interrogation,  // Dialogue Panel
        witnesses,      // Witness List Panel
        newspaper;      // Newspaper Image 
    public GameObject quest1, quest2, answer, wName; // Question 1, Question 2, answer, witnessname Gameobjects
    private Text q1, q2, a, n; // Question 1, Question 2, answer, witnessname Textfields
    private bool davies, donovan, richardson, smith, baxter, green, kent, pizer, chandler; // true > currently interrogating
    

    void Start()
    {
        q1 = quest1.GetComponent<Text>();
        q2 = quest2.GetComponent<Text>();
        a = answer.GetComponent<Text>();
        n = wName.GetComponent<Text>();

        davies = donovan = richardson = smith = baxter = green = kent = pizer = false;
        // Fill all Witness Dialogue Lists
        FillListDavies();
        FillListDonovan();
        FillListRichardson();
        FillListSmith();
        FillListBaxter();
        FillListPizer();
        FillListChandler();
    }

    //Close current Witness interrogation and return to overwview screen
    public void Close()
    {
        davies = donovan = richardson = smith = baxter = green = kent = pizer = chandler = false; // set all false > no one currently interrogated
        //Fill all Lists again so User can ask Witnesses again.
        FillListDavies();
        FillListDonovan();
        FillListRichardson();
        FillListSmith();
        FillListBaxter();
        FillListPizer();
        FillListChandler();
        
        witnesses.SetActive(true);
        interrogation.SetActive(false);
        q1.text = "";
        q2.text = "";
        newspaper.SetActive(true);
    }

    // Called if Question 1 is asked
    public void Q1()
    {
        // check which witness is currently interrogated
        // Chose the answer for current question and fill answer text with it
        // then, Remove that question from the list > already asked
        if (davies)
        {
            foreach (DialogueQuest q in optionsDavies)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsDavies.Remove(q);
                    break;
                }
            }
            // get next question
            if (optionsDavies.Count > 2)
            {
                q1.text = optionsDavies[2].question;
            }
            // empty the question if all questions are asked
            else
            {
                q1.text = "";
            }
        }
        if (donovan)
        {
            foreach (DialogueQuest q in optionsDonovan)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsDonovan.Remove(q);
                    break;
                }
            }
            if (optionsDonovan.Count > 2)
            {
                q1.text = optionsDonovan[2].question;
            }
            else
            {
                q1.text = "";
            }
        }
        if (richardson)
        {
            foreach (DialogueQuest q in optionsRichardson)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsRichardson.Remove(q);
                    break;
                }
            }
            if (optionsRichardson.Count > 2)
            {
                q1.text = optionsRichardson[2].question;
            }
            else
            {
                q1.text = "";
            }
        }
        if (smith)
        {
            foreach (DialogueQuest q in optionsSmith)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsSmith.Remove(q);
                    break;
                }
            }
            if (optionsSmith.Count > 2)
            {
                q1.text = optionsSmith[2].question;
            }
            else
            {
                q1.text = "";
            }
        }
        if (baxter)
        {
            foreach (DialogueQuest q in optionsBaxter)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsBaxter.Remove(q);
                    break;
                }
            }
            if (optionsBaxter.Count > 2)
            {
                q1.text = optionsBaxter[2].question;
            }
            else
            {
                q1.text = "";
            }
        }
        if (pizer)
        {
            foreach (DialogueQuest q in optionsPizer)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsPizer.Remove(q);
                    break;
                }
            }
            if (optionsPizer.Count > 2)
            {
                q1.text = optionsPizer[2].question;
            }
            else
            {
                q1.text = "";
            }
        }
        if (chandler)
        {
            foreach (DialogueQuest q in optionsChandler)
            {
                if (q1.text == q.question)
                {
                    a.text = q.answer;
                    optionsChandler.Remove(q);
                    break;
                }
            }
            if (optionsChandler.Count > 2)
            {
                q1.text = optionsChandler[2].question;
            }
            else
            {
                q1.text = "";
            }
        }
    }

    // Called if Question 2 is asked
    public void Q2()
    {
        // check which witness is currently interrogated
        // Chose the answer for current question and fill answer text with it
        // then, Remove that question from the list > already asked
        if (davies)
        {
            foreach (DialogueQuest q in optionsDavies)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsDavies.Remove(q);
                    break;
                }
            }
            // get next question
            if (optionsDavies.Count > 2)
            {
                q2.text = optionsDavies[2].question;
            }
            // empty the question if all questions are asked
            else
            {
                q2.text = "";
            }
        }
        if (donovan)
        {
            foreach (DialogueQuest q in optionsDonovan)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsDonovan.Remove(q);
                    break;
                }
            }
            if (optionsDonovan.Count > 2)
            {
                q2.text = optionsDonovan[2].question;
            }
            else
            {
                q2.text = "";
            }
        }
        if (richardson)
        {
            foreach (DialogueQuest q in optionsRichardson)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsRichardson.Remove(q);
                    break;
                }
            }
            if (optionsRichardson.Count > 2)
            {
                q2.text = optionsRichardson[2].question;
            }
            else
            {
                q2.text = "";
            }
        }
        if (smith)
        {
            foreach (DialogueQuest q in optionsSmith)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsSmith.Remove(q);
                    break;
                }
            }
            if (optionsSmith.Count > 2)
            {
                q2.text = optionsSmith[2].question;
            }
            else
            {
                q2.text = "";
            }
        }
        if (baxter)
        {
            foreach (DialogueQuest q in optionsBaxter)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsBaxter.Remove(q);
                    break;
                }
            }
            if (optionsBaxter.Count > 2)
            {
                q2.text = optionsBaxter[2].question;
            }
            else
            {
                q2.text = "";
            }
        }
        if (pizer)
        {
            foreach (DialogueQuest q in optionsPizer)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsPizer.Remove(q);
                    break;
                }
            }
            if (optionsPizer.Count > 2)
            {
                q2.text = optionsPizer[2].question;
            }
            else
            {
                q2.text = "";
            }
        }
        if (chandler)
        {
            foreach (DialogueQuest q in optionsChandler)
            {
                if (q2.text == q.question)
                {
                    a.text = q.answer;
                    optionsChandler.Remove(q);
                    break;
                }
            }
            if (optionsChandler.Count > 2)
            {
                q2.text = optionsChandler[2].question;
            }
            else
            {
                q2.text = "";
            }
        }
    }

    /*--------------------------------------------------------------------------------------*/
    /* Following Regions First Fill the Witnesses List with Questions and Answers           */
    /* Then they have a method to Fill Question Textfields and Answer Textfields of witness */
     
    //10.09.1888
    #region Davies
    void FillListDavies()
    {
        // Clear > no double entries
        optionsDavies.Clear();

        // Fill Questions and Answers
        DialogueQuest q;
        string ans;
        string quest;
        #region Option1
        // Option 1-1
        quest = "When you went into the yard on Saturday morning, was the yard door open or shut?";
        ans = " I found it shut. I cannot say whether it was latched - I cannot remember. I have been too much upset. " +
            "The front street door was wide open and thrown against the wall. I was not surprised to find the front door open, as it was not unusual. " +
            "I opened the back door, and stood in the entrance.";
        q = new DialogueQuest(quest, ans);
        optionsDavies.Add(q);
        // Option 1-2;
        quest = "Will you describe the yard?";
        ans = " It is a large yard. Facing the door, on the opposite side, on my left as I was standing, there is a shed, in which Mrs. Richardson keeps her wood. " +
            "In the right-hand corner there is a closet. The yard is separated from the next premises on both sides by close wooden fencing, about 5 ft. 6 in. high";
        q = new DialogueQuest(quest, ans);
        optionsDavies.Add(q);
        #endregion
        
        #region Option2
        // Option 2-1
        quest = "Where did you see those men before?";
        ans = "They work at Mr. Bailey's, a packing-case maker, of Hanbury-street.";
        q = new DialogueQuest(quest, ans);
        optionsDavies.Add(q);
        // Option 2-2;
        quest = "Why didn't you check the condition of the woman?";
        ans = "As I said, Any one who knows where the latch of the front door is could open it and go along the passage into the back yard. " +
            "It is not uncommon for homeless to sleep somewhere on the ground or in a backyard. I thought she was sleeping";
        q = new DialogueQuest(quest, ans);
        optionsDavies.Add(q);
        #endregion
        
        #region Option3
        // Option 3-1
        quest = "Have you ever seen the deceased before? ";
        ans = "No.";
        q = new DialogueQuest(quest, ans);
        optionsDavies.Add(q);
        // Option 3-2;
        quest = "Did you hear any noise that Saturday morning? ";
        ans = "No, Sir.";
        q = new DialogueQuest(quest, ans);
        optionsDavies.Add(q);
        #endregion
    }
    public void SetDavies()
    {
        a.text = "I am a carman employed at Leadenhall Market. I have lodged at 29, Hanbury-street for a fortnight, " +
            "and I occupied the top front room on the third floor with my wife and three sons, who live with me. " +
            "On Friday night I went to bed at eight o'clock, and my wife followed about half an hour later. " +
            "My sons came to bed at different times, the last one at about a quarter to eleven. There is a weaving shed window, or light across the room. " +
            "It was not open during the night. I was awake from three a.m. to five a.m. on Saturday, and then fell asleep until a quarter to six, " +
            "when the clock at Spitalfields Church struck. I had a cup of tea and went downstairs to the back yard. The house faces Hanbury-street, " +
            "with one window on the ground floor and a front door at the side leading into a passage which runs through into the yard. " +
            "There is a back door at the end of this passage opening into the yard. Neither of the doors was able to be locked, and I have never seen them locked. " +
            "Any one who knows where the latch of the front door is could open it and go along the passage into the back yard.";
        q1.text = optionsDavies[0].question;
        q2.text = optionsDavies[1].question;
        n.text = "John Davies";
        davies = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);
        newspaper.SetActive(false);
    }
    #endregion
    #region Donovan
    void FillListDonovan()
    {
        optionsDonovan.Clear();

        DialogueQuest q;
        string ans;
        string quest;
        #region Option1
        // Option 1-1
        quest = "How much was it?";
        ans = " Eightpence for the night. The bed she occupied, No. 29, was the one that she usually occupied. Deceased was then eating potatoes, and went out. " +
            "She stood in the door two or three minutes, and then repeated, 'Never mind, Tim; I shall soon be back. Don't let the bed.' " +
            "It was then about ten minutes to two a.m. She left the house, going in the direction of Brushfield-street. " +
            "John Evans, the watchman, saw her leave the house. I did not see her again.";
        q = new DialogueQuest(quest, ans);
        optionsDonovan.Add(q);
        // Option 1-2;
        quest = "Was she the worse for drink when you saw her last? ";
        ans = " She had had enough; of that I am certain. She walked straight. Generally on Saturdays she was the worse for drink. She was very sociable in the kitchen. " +
            "I said to her, 'You can find money for your beer, and you can't find money for your bed.' " +
            "She said she had been only to the top of the street - where there is a public-house";
        q = new DialogueQuest(quest, ans);
        optionsDonovan.Add(q);
        #endregion
        #region Option2
        // Option 2-1
        quest = "Did you see her with any man that night? ";
        ans = " No, sir. At other times she has come with other men, and I have refused her";
        q = new DialogueQuest(quest, ans);
        optionsDonovan.Add(q);
        // Option 2-2;
        quest = "Where did you think she was going to get the money from?  ";
        ans = " I did not know. She used to come and stay at the lodging-house on Saturdays with a man - a pensioner - of soldierly appearance, whose name I do not know.";
        q = new DialogueQuest(quest, ans);
        optionsDonovan.Add(q);
        #endregion
        #region Option3
        // Option 3-1
        quest = "You only allow the women at your place one husband?";
        ans = " The pensioner told me not to let her a bed if she came with any other man. She did not come with a man that night. I never saw her with any man that week";
        q = new DialogueQuest(quest, ans);
        optionsDonovan.Add(q);
        // Option 3-2;
        quest = "When was the pensioner last with deceased at the lodging-house?  ";
        ans = "On Sunday, Sept. 2. I cannot say whether they left together. I have heard the deceased say, 'Tim, wait a minute.I am just going up the street to see if I can see him.' " +
            "She added that he was going to draw his pension. This occurred on Saturday, Aug. 25, at three a.m.";
        q = new DialogueQuest(quest, ans);
        optionsDonovan.Add(q);
        #endregion
    }
    public void SetDonovan()
    {
        a.text = "I am the deputy of a common lodging house. I have seen the body of the deceased, and have identified it as that of a woman who stayed at my house for the last four months." +
            "She was not there last week until Friday afternoon, between two and three o'clock. " +
            "I was coming out of the office after getting up, and she asked me if she could go down in the kitchen, and I said 'Yes,# and asked her where she had been all the week. " +
            "She replied that she had been in the infirmary, but did not say which. " +
            "Deceased went down in the kitchen, and I did not see her again until half-past one or a quarter to two on Saturday morning. " +
            "At that time I was sitting in the office, which faces the front door.She went into the kitchen. " +
            "I sent the watchman's wife, who was in the office with me, downstairs to ask her husband about the bed. Deceased came upstairs to the office and said, " +
            "'I have not sufficient money for my bed. Don't let it.I shan't be long before I am in'";
        q1.text = optionsDonovan[0].question;
        q2.text = optionsDonovan[1].question;
        n.text = "Timothy Donovan";
        donovan = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);

        newspaper.SetActive(false);
    }
    #endregion

    //12.09.88
    #region Richardson
    void FillListRichardson()
    {
        optionsRichardson.Clear();
        DialogueQuest q;
        string ans;
        string quest;
        
        quest = "Which room do you occupy? ";
        ans = " The first floor front, and my grandson slept in the same room on Friday night. I went to bed about half-past nine, and was very wakeful half the night. " +
            "I was awake at three a.m., and only dozed after that.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
        
        quest = "Did you hear any noise during the night?";
        ans = " No";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
        
        quest = "Were the front and back doors always left open? ";
        ans = " Yes, you can open the front and back doors of any of the houses about there. They are all let out in rooms. People are coming in or going out all the night. ";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
        
        quest = "Did you ever see anyone in the passage?";
        ans = "Yes, about a month ago I heard a man on the stairs. I called Thompson, and the man said he was waiting for market." +
            "It was between half-past three and four o'clock. I could hear anyone going through the passage. I did not hear any one going through on Saturday morning";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
               
        quest = "You heard no cries? ";
        ans = " None.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
       
        quest = "Supposing a person had gone through at half-past three, would that have attracted your attention? ";
        ans = "Yes.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
       
        quest = "On Saturday morning you feel confident no one did go through?";
        ans = " Yes; I should have heard the sound. They must have walked purposely quietly or I should have heard them.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
        
        quest = "People go there who have no business to do so? ";
        ans = "Yes; I daresay they do.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);

        quest = "Had you an idea at any time that a part of the house or yard was used for an immoral purpose?";
        ans = "No, sir.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);

        quest = "Did you say anything about a leather apron? ";
        ans = "Yes, my son wears one when he works in the cellar.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);

        quest = "It is rather a dangerous thing to wear, is it not?";
        ans = "Yes. On Thursday, Sept. 6, I found my son's leather apron in the cellar mildewed. He had not used it for a month. " +
            "I took it and put it under the tap in the yard, and left it there. It was found there on Saturday morning by the police, who took charge of it. " +
            "The apron had remained there from Thursday to Saturday.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);

        quest = "Did you ever know of strange women being found on the first-floor landing? Your son had never spoken to you about it?";
        ans = "No.";
        q = new DialogueQuest(quest, ans);
        optionsRichardson.Add(q);
    }
    public void SetRichardson()
    {
        a.text = "I am a widow, and occupy half of the house - i.e., the first floor, ground floor, and workshops in the cellar. " +
            "I carry on the business of a packing-case maker there, and the shops are used by my son John, aged thirty-seven, and a man Francis Tyler, who have worked for me eighteen years. " +
            "The latter ought to have come at six a.m., but he did not arrive until eight o'clock, when I sent for him. " +
            "He is often late when we are slack. My son lives in John-street, Spitalfields, and he works also in the market on market mornings. " +
            "At six a.m. my grandson, Thomas Richardson, aged fourteen, who lives with me, got up. " +
            "I sent him down to see what was the matter, as there was so much noise in the passage. He came back and said, 'Oh, grandmother, there is a woman murdered.' " +
            "I went down immediately, and saw the body of the deceased lying in the yard. There was no one there at the time, but there were people in the passage. " +
            "Soon afterwards a constable came and took possession of the place. As far as I know the officer was the first to enter the yard.";
        q1.text = optionsRichardson[0].question;
        q2.text = optionsRichardson[1].question;
        n.text = "Amelia Richardson";
        richardson = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);

        newspaper.SetActive(false);
    }
    #endregion
    #region Smith
    void FillListSmith()
    {
        optionsSmith.Clear();
        DialogueQuest q;
        string ans;
        string quest;
        quest = "Did you know anything about her associates?";
        ans = "No";
        q = new DialogueQuest(quest, ans);
        optionsSmith.Add(q);
        quest = "How old was she?";
        ans = "47, Sir";
        q = new DialogueQuest(quest, ans);
        optionsSmith.Add(q);
    }
    public void SetSmith()
    {
        a.text = "I have seen the body in the mortuary, and recognise it as that of my eldest sister, Annie, the widow of John Chapman, who lived at Windsor, a coachman. " +
            "She had been separated from her husband for about three years. Her age was forty-seven. " +
            "I last saw her alive a fortnight ago, in Commercial-street, where I met her promiscuously. Her husband died at Christmas, 1886. " +
            "I gave her 2s; she did not say where she was living nor what she was doing. She said she wanted the money for a lodging.";
        q1.text = optionsSmith[0].question;
        q2.text = optionsSmith[1].question;
        n.text = "Fontain Smith";
        smith = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);
        newspaper.SetActive(false);
    }
    #endregion
    #region Kent/Green
    public void SetKent() {
        a.text = "I work for Mr. Bayley, 23A, Hanbury-street, and go there at six a.m. On Saturday I arrived about ten minutes past that hour. " +
            "Our employer's gate was open, and there I waited for some other men. Davis, who lives two or three doors away, ran from his house into the road and cried, 'Men, come here.' " +
            "James Green and I went together to 29, Hanbury-street, and on going through the passage, standing on the top of the back door steps, " +
            "I saw a woman lying in the yard between the steps and the partition between the yard and the next. Her head was near the house, but no part of the body was against the wall. " +
            "The feet were lying towards the back of Bayley's premises. (Witness indicated the precise position upon a plan produced by the police-officers). " +
            "Deceased's clothes were disarranged, and her apron was thrown over them. I did not go down the steps, but went outside and returned after Inspector Chandler had arrived. " +
            "I could see that the woman was dead. She had some kind of handkerchief around her throat which seemed soaked in blood. " +
            "The face and hands were besmeared with blood, as if she had struggled. She appeared to have been on her back and fought with her hands to free herself. " +
            "The hands were turned toward her throat. The legs were wide apart, and there were marks of blood upon them. The entrails were protruding, and were lying across her left side. " +
            "I got a piece of canvass from the shop to throw over the body, and by that time a mob had assembled, and Inspector Chandler was in possession of the yard. " +
            "The foreman gets to the shop at ten minutes to six every morning, and he was there before us.";
        q1.text = "";
        q2.text = "";
        n.text = "James Kent";
        kent = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);
        newspaper.SetActive(false);
    }
    public void SetGreen()
    {
        a.text = "I arrived in Hanbury-street at ten minutes past six on Saturday morning, and accompanied Kent to the back door of No. 29. I left the premises with him. " +
            "I saw no one touch the body.";
        q1.text = "";
        q2.text = "";
        n.text = "James Green";
        green = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);
        newspaper.SetActive(false);
    }
    #endregion

    //13.09.88
    #region Baxter
    void FillListBaxter()
    {
        optionsBaxter.Clear();

        DialogueQuest q;
        string ans;
        string quest;
        
        quest = "What kind of mortuary was the body brought to?";
        ans = "The mortuary is not fitted for a post-mortem examination. It is only a shed. " +
            "There is no adequate convenience, and nothing fit, and at certain seasons of the year it is dangerous to the operator";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Why were she brought to this mortuary?";
        ans = "As a matter of fact there is no other public mortuary from the City of London up to Bow. There is one at Mile-end, but it belongs to the workhouse, and is not used for general purposes.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Possibly you can give us the conclusions to which you have come respecting the instrument used?";
        ans = "It must have been a very sharp knife, probably with a thin, narrow blade, and at least six to eight inches in length, and perhaps longer.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "You can give your opinion as to how the death was caused.";
        ans = "From these appearances I am of opinion that the breathing was interfered with previous to death, and that death arose from syncope, or failure of the heart's action, " +
            "in consequence of the loss of blood caused by the severance of the throat.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Would it have been such an instrument as a medical man uses for post-mortem examinations?";
        ans = "The ordinary post-mortem case perhaps does not contain such a weapon. ";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Is it possible that any instrument used by a military man, such as a bayonet, would have done it? ";
        ans = "No; it would not be a bayonet.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Was there any anatomical knowledge displayed?";
        ans = " - I think there was. There were indications of it. My own impression is that that anatomical knowledge was only less displayed or indicated in consequence of haste. " +
            "The person evidently was hindered from making a more complete dissection in consequence of the haste";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Was the whole of the body there?";
        ans = "No; the absent portions being from the abdomen. I think the mode in which they were extracted did show some anatomical knowledge.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "How long had the deceased been dead when you saw her?";
        ans = "I should say at least two hours, and probably more; " +
            "but it is right to say that it was a fairly cold morning, and that the body would be more apt to cool " +
            "rapidly from its having lost the greater portion of its blood.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Was there any evidence of any struggle?";
        ans = "No; not about the body of the woman. You do not forget the smearing of blood about the palings";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "In your opinion did she enter the yard alive?";
        ans = "I am positive of it. I made a thorough search of the passage, and I saw no trace of blood, which must have been visible had she been taken into the yard.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "You were shown the apron?";
        ans = "I saw it myself. There was no blood upon it. It had the appearance of not having been unfolded recently";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Was the bruising you mentioned recent?";
        ans = "The marks on the face were recent, especially about the chin and sides of the jaw. " +
            "The bruise upon the temple and the bruises in front of the chest were of longer standing, probably of days. " +
            "I am of opinion that the person who cut the deceased's throat took hold of her by the chin, and then commenced the incision from left to right. ";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Could the murder have happend so instantaneously that a person could not cry out?";
        ans = "By pressure on the throat no doubt it would be possible.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
        quest = "Can you give any idea how long it would take to perform the incisions found on the body? ";
        ans = "I think I can guide you by saying that I myself could not have performed all the injuries I saw on that woman, and effect them, " +
            "even without a struggle, under a quarter of an hour. If I had done it in a deliberate way, such as would fall to the duties of a surgeon, " +
            "it would probably have taken me the best part of an hour. " +
            "The whole inference seems to me that the operation was performed to enable the perpetrator to obtain possession of these parts of the body. ";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
       
        quest = "Is there anything to indicate that the crime in the case of the woman Nicholls was perpetrated with the same object as this? ";
        ans = ": I have no particular opinion upon that point myself. I was asked about it very early in the inquiry, and I gave my opinion that the operation would be useless, " +
            "especially in this case. The use of a blood-hound was also suggested. It may be my ignorance, but the blood around was that of the murdered woman, " +
            "and it would be more likely to be traced than the murderer. These questions were submitted to me by the police very early. " +
            "I think within twenty- four hours of the murder of the woman.";
        q = new DialogueQuest(quest, ans);
        optionsBaxter.Add(q);
        
    }
    public void SetBaxter()
    {
        a.text = "On Saturday last I was called by the police at 6.20 a.m. to 29, Hanbury-street, and arrived at half-past six. " +
            "I found the body of the deceased lying in the yard on her back, on the left hand of the steps that lead from the passage. " +
            "The head was about 6in in front of the level of the bottom step, and the feet were towards a shed at the end of the yard. " +
            "The left arm was across the left breast, and the legs were drawn up, the feet resting on the ground, and the knees turned outwards. " +
            "The face was swollen and turned on the right side, and the tongue protruded between the front teeth, but not beyond the lips; it was much swollen. " +
            "The small intestines and other portions were lying on the right side of the body on the ground above the right shoulder, but attached. " +
            "There was a large quantity of blood, with a part of the stomach above the left shoulder. I searched the yard and found a small piece of coarse muslin, a small-tooth comb, " +
            "and a pocket-comb, in a paper case, near the railing. They had apparently been arranged there. I also discovered various other articles, which I handed to the police. " +
            "The body was cold, except that there was a certain remaining heat, under the intestines, in the body. Stiffness of the limbs was not marked, but it was commencing. " +
            "The throat was dissevered deeply. I noticed that the incision of the skin was jagged, and reached right round the neck. On the back wall of the house, " +
            "between the steps and the palings, on the left side, about 18in from the ground, there were about six patches of blood, varying in size from a " +
            "sixpenny piece to a small point, and on the wooden fence there were smears of blood, corresponding to where the head of the deceased laid, and immediately " +
            "above the part where the blood had mainly flowed from the neck, which was well clotted. Having received instructions soon after two o'clock on Saturday afternoon, " +
            "I went to the labour- yard of the Whitechapel Union for the purpose of further examining the body and making the usual post-mortem investigation. " +
            "I was surprised to find that the body had been stripped and was laying ready on the table. It was under great disadvantage I made my examination. " +
            "As on many occasions I have met with the same difficulty, I now raise my protest, as I have before, that members of my profession should be called upon to perform " +
            "their duties under these inadequate circumstances.";
        q1.text = optionsBaxter[0].question;
        q2.text = optionsBaxter[1].question;
        n.text = "Dr. George Baxter Phillips, divisional-surgeon of police";
        baxter = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);

        newspaper.SetActive(false);
    }
    #endregion
    #region Pfizer
    void FillListPizer()
    {
        optionsPizer.Clear();

        DialogueQuest q;
        string ans;
        string quest;

        quest = "Are you known by the nickname of 'Leather Apron?'";
        ans = "Yes, sir.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "What time did you reach 22, Mulberry-street?";
        ans = "Shortly before eleven p.m.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "Who lives at 22, Mulberry-street?";
        ans = "My brother and sister-in-law and my stepmother. I remained indoors there.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "Until when did you stay at 22, Mulberry-street?";
        ans = "Until I was arrested by Sergeant Thicke, on Monday last at nine a.m. I never left the house.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "Why were you remaining there?";
        ans = "Because my brother advised me. I was the object of a false suspicion.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "Can you tell us where you were on Thursday, Aug. 30?";
        ans = "In the Holloway-road. I was staying at a common lodging-house called the Round House, in the Holloway-road. ";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "Can you tell us where you were on Friday, Aug. 31 in the morning?";
        ans = "At eleven p.m. on Thursday I had my supper at the Round House. I did go out after that, as far as the Seven Sisters-road, and then returned towards Highgate way, 1" +
            "down the Holloway-road. Turning, I saw the reflection of a fire. Coming as far as the church in the Holloway-road I saw two constables and the lodging-housekeeper talking together. " +
            "There might have been one or two constables, I cannot say which. I asked a constable where the fire was, and he said it was a long way off. " +
            "I asked him where he thought it was, and he replied: 'Down by the Albert Docks.' It was then about half-past one, to the best of my recollection. " +
            "I went as far as Highbury Railway Station on the same side of the way, returned, and then went into the lodging house.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);

        quest = "Is there anything else you want to say?";
        ans = "Nothing.";
        q = new DialogueQuest(quest, ans);
        optionsPizer.Add(q);
    }
    public void SetPfizer()
    {
        a.text = "I live at 22, Mulberry-street, Commercial- road East. I am a shoemaker.";
        q1.text = optionsPizer[0].question;
        q2.text = optionsPizer[1].question;
        n.text = "John Pizer, Suspect";
        pizer = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);
        newspaper.SetActive(false);
    }
    #endregion
    #region Chandler
    void FillListChandler()
    {
        optionsChandler.Clear();

        DialogueQuest q;
        string ans;
        string quest;

        quest = "What was on the envelope?";
        ans = "On the back there was a seal with the words, embossed in blue, 'Sussex Regiment.' The other part was torn away. On the other side there was a letter 'M' in writing.";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Any postage stamp on the letter?";
        ans = "No. There was a postal stamp 'London, Aug. 3, 1888.' That was in red. There was another black stamp, which was indistinct. " +
            "There were also the letters 'Sp' lower down, as if some one had written 'Spitalfields.' The other part was gone. There were no other marks.";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Did you find anything else in the yard?";
        ans = "Yes. There was also a box, such as is commonly used by casemakers for holding nails. It was empty. " +
            "There was also a piece of steel, flat, which has since been identified by Mrs. Richardson as the spring of her son's leggings. " +
            "It was close to where the body had been. The apron and nail box have also been identified by her as her property. " +
            "The yard was paved roughly with stones in parts; in other places it was earth. ";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Was there any appearance of a struggle there? ";
        ans = "No.";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Is there any evidence of anybody having got over the pailings?";
        ans = "No. Some of them in the adjoining yard have been broken since. They were not broken then.";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Was there any staining as of blood on any of the palings?";
        ans = "Yes, near the body, not on the other yards though.";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Were there any drops of blood outside the yard of No. 29?";
        ans = "No; every possible examination has been made, but we could find no trace of them. The blood-stains at No. 29 were in the immediate neighbourhood of the body only. " +
            "There were also a few spots of blood on the back wall, near the head of the deceased, 2ft from the ground. The largest spot was of the size of a sixpence. " +
            "They were all close together. I assisted in the preparation of the plan produced, which is correct.";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);

        quest = "Did you search the body? ";
        ans = "I searched the clothing at the mortuary. The outside jacket - a long black one, which came down to the knees - had bloodstains round the neck, both upon the inside and out, " +
            "and two or three spots on the left arm. The jacket was hooked at the top, and buttoned down the front. By the appearance of the garment there did not seem to have been any struggle. " +
            "A large pocket was worn under the skirt (attached by strings), which I produce. It was torn down the front and also at the side, and it was empty. Deceased wore a black skirt. " +
            "There was a little blood on the outside. The two petticoats were stained very little; the two bodices were stained with blood round the neck, but they had not been damaged. " +
            "There was no cut in the clothing at all. The boots were on the feet of deceased. They were old. No part of the clothing was torn. The stockings were not bloodstained. .";
        q = new DialogueQuest(quest, ans);
        optionsChandler.Add(q);
    }
    public void SetChandler()
    {
        a.text = "On Saturday morning, at ten minutes past six, I was on duty in Commercial-street. " +
            "At the corner of Hanbury-street I saw several men running. I beckoned to them. One of them said, 'Another woman has been murdered.' " +
            "I at once went with him to 29, Hanbury-street, and through the passage into the yard. There was no one in the yard. " +
            "I saw the body of a woman lying on the ground on her back. Her head was towards the back wall of the house, nearly two feet from the wall, " +
            "at the bottom of the steps, but six or nine inches away from them. The face was turned to the right side, and the left arm was resting on the left breast. " +
            "The right hand was lying down the right side. Deceased's legs were drawn up, and the clothing was above the knees. A portion of the intestines, still connected with the body, " +
            "were lying above the right shoulder, with some pieces of skin. There were also some pieces of skin on the left shoulder. " +
            "The body was lying parallel with the fencing dividing the two yards. I remained there and sent for the divisional surgeon, " +
            "Mr. Phillips, and to the police-station for the ambulance and for further assistance. When the constables arrived I cleared the passage of people, " +
            "and saw that no one touched the body until the doctor arrived. I obtained some sacking to cover it before the arrival of the surgeon, who came at " +
            "about half- past six o'clock, and he, having examined the body, directed that it should be removed to the mortuary. After the body had been taken away " +
            "I examined the yard, and found a piece of coarse muslin, a small tooth comb, and a pocket hair comb in a case. They were lying near the feet of the woman. " +
            "A portion of an envelope was found near her head, which contained two pills.";
        q1.text = optionsChandler[0].question;
        q2.text = optionsChandler[1].question;
        n.text = "Joseph Chandler, Inspector H Division Metropolitan Police";
        chandler = true;
        interrogation.SetActive(true);
        witnesses.SetActive(false);

        newspaper.SetActive(false);
    }
    #endregion
}
