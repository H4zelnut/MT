using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueQuest
{
    public string question;
    public string answer;

    public DialogueQuest (string q, string a)
    {
        this.question = q;
        this.answer = a;
    }
}
