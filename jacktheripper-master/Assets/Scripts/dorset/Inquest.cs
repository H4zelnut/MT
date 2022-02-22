using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Inquest Day Millers Court/Dorset Street
//Ask witnesses
//notes added to notebook
public class Inquest : MonoBehaviour
{
    //Statements consisting of:
    //statement text 
    //summary of statement as notebook note
    struct Statement
    {
        public string statement;
        public string point;

        public Statement(string statement, string point)
        {
            this.statement = statement;
            this.point = point;
        }
    }
    public GameObject Speech, Picture, Name, Notes; //Gameobjects for filling
    public Sprite ph, ba, ab, coxx; //ph=phillips, ba=barnett, ab=abberline, coxx= cox
    List<Statement> phillips, barnett, cox, abberline; //Lists for each witness
    bool p, b, c, a = false; //sets current witness. p=phillips, b=barnett, a=abberline, c= cox
    List<bool> p5, a5, b5, c5; //Lists with bools for each witness. If true > statement[index] already given
    string noteB, noteA, noteC, noteP; //notetool for filling

    void Start()
    {
        //fill all
        phillips = new List<Statement>();
        Phillips();
        barnett = new List<Statement>();
        Barnett();
        cox = new List<Statement>();
        Cox();
        abberline = new List<Statement>();
        Abberline();

        #region boolz
        p5 = new List<bool>();
        p5.Add(false);
        p5.Add(false);
        p5.Add(false);
        p5.Add(false);
        p5.Add(false);

        a5 = new List<bool>();
        a5.Add(false);
        a5.Add(false);
        a5.Add(false);
        a5.Add(false);
        a5.Add(false);

        b5 = new List<bool>();
        b5.Add(false);
        b5.Add(false);
        b5.Add(false);
        b5.Add(false);
        b5.Add(false);

        c5 = new List<bool>();
        c5.Add(false);
        c5.Add(false);
        c5.Add(false);
        c5.Add(false);
        c5.Add(false);
        #endregion

        //Set abberline as starting character
        Picture.GetComponent<Image>().sprite = ab;
        Speech.GetComponent<Text>().text = abberline[0].statement;
        Name.GetComponent<Text>().text = "Inspector Abberline";
        a = true;
    }

    //switch to next statement of same person
    //check if next statement summary already in notebook
    // if no: add
    public void Next()
    {
        if (a)
        {
            for (int i = 0; i < abberline.Count; i++)
            {
                if(abberline[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != abberline.Count - 1)
                    {
                        Speech.GetComponent<Text>().text = abberline[i+1].statement;
                        if(a5[i + 1] == false)
                        {
                            noteA += abberline[i + 1].point + "\n";
                        }
                        a5[i + 1] = true;
                        break;
                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = abberline[0].statement;
                        if (a5[0] == false)
                        {
                            noteA += abberline[0].point + "\n";
                        }
                        a5[0] = true;
                        break;
                    }
                }
            }
            Notes.GetComponent<Text>().text = noteA;
        }
        else if (b)
        {
            for (int i = 0; i < barnett.Count; i++)
            {
                if (barnett[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != barnett.Count - 1)
                    {
                        Speech.GetComponent<Text>().text = barnett[i+1].statement;
                        if (b5[i + 1] == false)
                        {
                            noteB += barnett[i + 1].point + "\n";
                        }
                        b5[i + 1] = true;
                        break;

                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = barnett[0].statement;
                        if (b5[0] == false)
                        {
                            noteB += barnett[0].point + "\n";
                        }
                        b5[0] = true;
                        break;

                    }
                }
            }
            Notes.GetComponent<Text>().text = noteB;
        }
        else if (p)
        {
            for (int i = 0; i < phillips.Count; i++)
            {
                if (phillips[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != phillips.Count - 1)
                    {
                        Speech.GetComponent<Text>().text = phillips[i+1].statement;
                        if (p5[i + 1] == false)
                        {
                            noteP += phillips[i + 1].point + "\n";
                        }
                        p5[i + 1] = true;
                        break;

                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = phillips[0].statement;
                        if (p5[0] == false)
                        {
                            noteP += phillips[0].point + "\n";
                        }
                        p5[0] = true;
                        break;

                    }
                }
            }
            Notes.GetComponent<Text>().text = noteP;
        }
        else if (c)
        {
            for (int i = 0; i < cox.Count; i++)
            {
                if (cox[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != cox.Count - 1)
                    {
                        Speech.GetComponent<Text>().text = cox[i+1].statement;
                        if (c5[i + 1] == false)
                        {
                            noteC += cox[i + 1].point + "\n";
                        }
                        c5[i + 1] = true;
                        break;

                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = cox[0].statement;
                        if (c5[0] == false)
                        {
                            noteC += cox[0].point + "\n";
                        }
                        c5[0] = true;
                        break;

                    }
                }
            }
            Notes.GetComponent<Text>().text = noteC;
        }
    }

    //switch to prev statement of same person
    //check if prev statement summary already in notebook
    // if no: add
    public void Prev()
    {
        if (a)
        {
            for (int i = 0; i < abberline.Count; i++)
            {
                if (abberline[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != 0)
                    {
                        Speech.GetComponent<Text>().text = abberline[i-1].statement;
                        if (a5[i - 1] == false)
                        {
                            noteA += abberline[i - 1].point + "\n";
                        }
                        a5[i - 1] = true;
                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = abberline[abberline.Count-1].statement;
                        if (a5[abberline.Count-1] == false)
                        {
                            noteA += abberline[abberline.Count-1].point + "\n";
                        }
                        a5[abberline.Count - 1] = true;
                    }
                }
            }
            Notes.GetComponent<Text>().text = noteA;
        }
        else if (b)
        {
            for (int i = 0; i < barnett.Count; i++)
            {
                if (barnett[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != 0)
                    {
                        Speech.GetComponent<Text>().text = barnett[i-1].statement;
                        if (b5[i - 1] == false)
                        {
                            noteB += barnett[i - 1].point + "\n";
                        }
                        b5[i - 1] = true;
                        
                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = barnett[barnett.Count-1].statement;
                        if (b5[barnett.Count - 1] == false)
                        {
                            noteB += barnett[barnett.Count - 1].point + "\n";
                        }
                        b5[barnett.Count - 1] = true;
                    }
                }
            }
            Notes.GetComponent<Text>().text = noteB;
        }
        else if (p)
        {
            for (int i = 0; i < phillips.Count; i++)
            {
                if (phillips[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != 0)
                    {
                        Speech.GetComponent<Text>().text = phillips[i-1].statement;
                        if (p5[i - 1] == false)
                        {
                            noteP += phillips[i - 1].point + "\n";
                        }
                        p5[i - 1] = true;
                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = phillips[phillips.Count-1].statement;
                        if (p5[phillips.Count-1] == false)
                        {
                            noteP += phillips[phillips.Count-1].point + "\n";
                        }
                        p5[phillips.Count - 1] = true;
                    }
                }
            }
            Notes.GetComponent<Text>().text = noteP;
        }
        else if (c)
        {
            for (int i = 0; i < cox.Count; i++)
            {
                if (cox[i].statement == Speech.GetComponent<Text>().text)
                {
                    if (i != 0)
                    {
                        Speech.GetComponent<Text>().text = cox[i-1].statement;
                        if (c5[i - 1] == false)
                        {
                            noteC += cox[i - 1].point + "\n";
                        }
                        c5[i - 1] = true;
                    }
                    else
                    {
                        Speech.GetComponent<Text>().text = cox[cox.Count-1].statement;
                        if (c5[cox.Count-1] == false)
                        {
                            noteC += cox[cox.Count-1].point + "\n";
                        }
                        c5[cox.Count - 1] = true;
                    }
                }
            }
            Notes.GetComponent<Text>().text = noteC;
        }
    }

    //switch to next witness
    //check which statement summaries of next witness are already in notebook and load
    public void For()
    {
        if (a)
        {
            b = true;
            Speech.GetComponent<Text>().text = barnett[0].statement;
            Name.GetComponent<Text>().text = "Joseph Barnett";
            Picture.GetComponent<Image>().sprite = ba;
            a = false;
            Notes.GetComponent<Text>().text = noteB;
        }
        else if (b)
        {
            c = true;
            Speech.GetComponent<Text>().text = cox[0].statement;
            Name.GetComponent<Text>().text = "Mary Ann Cox";
            Picture.GetComponent<Image>().sprite = coxx;
            b = false;
            Notes.GetComponent<Text>().text = noteC;
        }
        else if (c)
        {
            p = true;
            Speech.GetComponent<Text>().text = phillips[0].statement;
            Name.GetComponent<Text>().text = "George Baxter Phillips";
            Picture.GetComponent<Image>().sprite = ph;
            c = false;
            Notes.GetComponent<Text>().text = noteP;
        }
        else if (p)
        {
            a = true;
            Speech.GetComponent<Text>().text = abberline[0].statement;
            Name.GetComponent<Text>().text = "Inspector Abberline";
            Picture.GetComponent<Image>().sprite = ab;
            p = false;
            Notes.GetComponent<Text>().text = noteA;
        }
    }

    //switch to prev witness
    //check which statement summaries of prev witness are already in notebook and load
    public void Back()
    {
        if (a)
        {
            p = true;
            Speech.GetComponent<Text>().text = phillips[0].statement;
            Name.GetComponent<Text>().text = "George Baxter Phillips";
            Picture.GetComponent<Image>().sprite = ph;
            a = false;
            Notes.GetComponent<Text>().text = noteP;
        }
        else if (b)
        {
            a = true;
            Speech.GetComponent<Text>().text = abberline[0].statement;
            Name.GetComponent<Text>().text = "Inspector Abberline";
            Picture.GetComponent<Image>().sprite = ab;
            b = false;
            Notes.GetComponent<Text>().text = noteA;
        }
        else if (c)
        {
            b = true;
            Speech.GetComponent<Text>().text = barnett[0].statement;
            Name.GetComponent<Text>().text = "Joseph Barnett";
            Picture.GetComponent<Image>().sprite = ba;
            c = false;
            Notes.GetComponent<Text>().text = noteB;
        }
        else if (p)
        {
            c = true;
            Speech.GetComponent<Text>().text = cox[0].statement;
            Name.GetComponent<Text>().text = "Mary Ann Cox";
            Picture.GetComponent<Image>().sprite = coxx;
            p = false;
            Notes.GetComponent<Text>().text = noteC;
        }
    }


    //hardcoded statements of witnesses 
    //Called once for filling
    #region statements
    void Abberline()
    {
        string stating;
        string clue;

        stating = "I am in charge of this case. I arrived at Miller's-court about 11.30 on Friday morning. I had an intimation from Inspector Beck that the " +
            "bloodhounds had been sent for, and the reply had been received that they were on the way. Dr. Phillips was unwilling to force the door, as it would be " +
            "very much better to test the dogs, if they were coming. We remained until about 1.30 p.m., when Superintendent Arnold arrived, and he informed me " +
            "that the order in regard to the dogs had been countermanded, and he gave orders for the door to be forced. ";
        clue = "Waited until 1:30pm";
        abberline.Add(new Statement(stating, clue));

        stating = "I subsequently took an inventory of the contents of the room. There were traces of a large fire having been kept up in the grate, " +
            "so much so that it had melted the spout of a kettle off. We have since gone through the ashes in the fireplace; there were remnants of clothing, " +
            "a portion of a brim of a hat, and a skirt, and it appeared as if a large quantity of women's clothing had been burnt.";
        clue = "Clothes in the fireplace";
        abberline.Add(new Statement(stating, clue));

        stating = "I can only imagine that it was to make a light for the man to see what he was doing. There was only one small candle in the room, " +
            "on the top of a broken wine-glass, and the door was locked when we found it.";
        clue = "Room was quite dark";
        abberline.Add(new Statement(stating, clue));

        stating = "An impression has gone abroad that the murderer took away the key of the room. Barnett informs me that it has been missing some time, " +
            "and since it has been lost they have put their hand through the broken window, and moved back the catch. It is quite easy.";
        clue = "Missing Key";
        abberline.Add(new Statement(stating, clue));

        stating = "We also found a Caroline Maxwell who saw her on 10th of November at 8:30 AM. She admited that she did not know her very well.";
        clue = "Victim was seen at 8:30 AM on 10th November";
        abberline.Add(new Statement(stating, clue));
    }
    void Cox()
    {
        string stating;
        string clue;

        stating = "I live at No. 5 Room, Miller's-court. It is the last house on the left-hand side of the court. I am a widow, and get my living on the streets. " +
            "I have known the deceased for eight or nine months as the occupant of No. 13 Room. She was called Mary Jane. I last saw her alive on Thursday night, " +
            "at a quarter to twelve.";
        clue = "Mary Jane returned at 11:45 PM"; // press for Name
        cox.Add(new Statement(stating, clue));

        stating = "This was in Dorset-street. She went up the court, a few steps in front of me. A short, stout man, shabbily dressed was with her. " +
            "He had on a longish dark coat, very shabby, and carried a pot of ale in his hand. He had a blotchy face, and full carrotty moustache. The chin was shaven. " +
            "I said 'Good night, Mary' and she turned round and banged the door.";
        clue = "Kelly was in Company with a man.";
        cox.Add(new Statement(stating, clue));

        stating = "She said 'Good night, I am going to have a song.' As I went in she sang 'A violet I plucked from my mother's grave when a boy.' " +
            "I remained a quarter of an hour in my room and went out. Deceased was still singing at one o'clock when I returned. " +
            "I remained in the room for a minute to warm my hands as it was raining, and went out again. She was singing still, and I returned to my room at three o'clock. " +
            "The light was then out and there was no noise.";
        clue = "Kelly sang from 11:45 PM to 3:00 AM";
        cox.Add(new Statement(stating, clue));

        stating = "When I saw her, she had no hat; a red pelerine and a shabby skirt.";
        clue = "Victim wore no hat, red cape, shabby skirt";
        cox.Add(new Statement(stating, clue));

        stating = "When we met, she appeared to be very intoxicated. I did not notice she was drunk until she said good night. The man closed the door. She was quite " +
            "known for her drinking habits.";
        clue = "Drinks a lot"; // press for drunken
        cox.Add(new Statement(stating, clue));
    }
    void Barnett()
    {
        string stating;
        string clue;

        stating = "I was a fish-porter, and I work as a labourer and fruit- porter. Until Saturday last I lived at 24, New-street, Bishopsgate, and have since " +
            "stayed at my sister's, 21, Portpool-lane, Gray's Inn-road. I have lived with the deceased one year and eight months. " +
            "Her name was Marie Jeanette Kelly with the French spelling as described to me. Kelly was her maiden name. I have seen the body, " +
            "and I identify it. I am positive it is the same woman I knew. " +
            "I lived with her in No. 13 room, at Miller's-court for eight months. I separated from her on Oct. 30.";
        clue = "Recognized her with no doubt"; //press >  by the ear and eyes, which are all that I can recognise;
        barnett.Add(new Statement(stating, clue));

        stating = "Because she had a woman of bad character there, whom she took in out of compassion, and I objected to it. " +
            "That was the only reason. I left her on the Tuesday between five and six p.m. I last saw her alive between half-past seven and a quarter " +
            "to eight on Thursday night last, when I called upon her. I stayed there for a quarter of an hour.";
        clue = "Seperated because of a woman of bad character"; // ggf press 
        barnett.Add(new Statement(stating, clue));

        stating = "If we drank together? No, she was very sober.";
        clue = "Victim didn't drink much."; // ggf press 
        barnett.Add(new Statement(stating, clue));

        stating = "I first picked her up in Commercial-street. We then had a drink together, and I made arrangements to see her on the following day - a Saturday. " +
            "On that day we both of us agreed that we should remain together. I took lodgings in George-street, Commercial-street, where I was known. " +
            "I lived with her, until I left her, on very friendly terms";
        clue = "Leaves her on friendly terms"; 
        barnett.Add(new Statement(stating, clue));

        stating = "I have heard her speak of beaing afraid, yes. Several times. I bought newspapers, and I read to her everything about the murders, " +
            "which she asked me about. ";
        clue = "Victim was afraid of the murders";
        barnett.Add(new Statement(stating, clue));
    }
    void Phillips()
    {
        string stating;
        string clue;
        
        stating = "I was called by the police on Friday morning at eleven o'clock, and on proceeding to Miller's - court, which I entered at 11.15," +
            " I found a room, the door of which led out of the passage at the side of 26, Dorset - street, photographs of which I produce. " +
            "It had two windows in the court.";
        clue = "Arrived at 11:15 AM";
        phillips.Add(new Statement(stating, clue));

        stating = "Two panes in the lesser window were broken, and as the door was locked I looked through the lower of the broken panes and satisfied myself " +
            "that the mutilated corpse lying on the bed was not in need of any immediate attention from me, and I also came to the conclusion that there was " +
            "nobody else upon the bed, or within view, to whom I could render any professional assistance.";
        clue = "Checked life signs";
        phillips.Add(new Statement(stating, clue));

        stating = "Having ascertained that probably it was advisable that no entrance should be made into the room at that time, I remained until about 1.30p.m., " +
            "when the door was broken open by McCarthy, under the direction of Superintendent Arnold. On the door being opened it knocked against a table" +
            " which was close to the left-hand side of the bedstead, and the bedstead was close against the wooden partition. ";
        clue = "Door is broken by McCarthy";
        phillips.Add(new Statement(stating, clue));

        stating = "The mutilated remains of a woman were lying two-thirds over, towards the edge of the bedstead, nearest the door. " +
            "Deceased had only an under-linen garment upon her, and by subsequent examination I am sure the body had been removed, after the " +
            "injury which caused death, from that side of the bedstead which was nearest to the wooden partition previously mentioned.";
        clue = "Victim was mutilated beyond recognition";
        phillips.Add(new Statement(stating, clue));

        stating = "The large quantity of blood under the bedstead, the saturated condition of the palliasse, pillow, and sheet at the top corner of the " +
            "bedstead nearest to the partition leads me to the conclusion that the severance of the right carotid artery, which was the immediate cause of death, " +
            "was inflicted while the deceased was lying at the right side of the bedstead and her head and neck in the top right-hand corner at around 3:30AM of 10th November.";
        clue = "Victim died on the right side of the bed at around 3:30 AM";
        phillips.Add(new Statement(stating, clue));
    }
    #endregion
}
