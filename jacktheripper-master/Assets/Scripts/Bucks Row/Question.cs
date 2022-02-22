using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question
{
    public string question;
    public string ansA;
    public string ansB;
    public string ansC;
    public string ansD;
    public int rightAns;
    public int givenAns;
    

    public Question(string v1, string v2, string v3, string v4, string v5, int v6, int v7)
    {
        this.question = v1;
        this.ansA = v2;
        this.ansB = v3;
        this.ansC = v4;
        this.ansD = v5;
        this.rightAns = v6;
        this.givenAns = v7;
    }
}
