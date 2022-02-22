using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Person : MonoBehaviour
{
    public List<string> itemReaction;
    public Person(List<string> i)
    {
        this.itemReaction = i;
    }
}
