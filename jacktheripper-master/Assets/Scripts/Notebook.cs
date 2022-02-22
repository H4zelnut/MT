using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    struct Infos
    {
        public string one;
        public string two;
        public int idx;

        public Infos(string one, string two, int idx)
        {
            this.one = one;
            this.two = two;
            this.idx = idx;
        }
    }
    public GameObject noteL, noteR, next, prev;
    List<Infos> information;
    bool first;
    private void Start()
    {
        information = new List<Infos>();
        first = true;
    }
    public void Next()
    {
        if(information.Count > 1)
        {
            noteL.GetComponentInChildren<Text>().text = information[1].one;
            noteR.GetComponentInChildren<Text>().text = information[1].two;
            information.Add(information[0]);
            information.RemoveAt(0);
        }
    }
    public void Prev()
    {
        if (information.Count > 1)
        {
            noteL.GetComponentInChildren<Text>().text = information[information.Count-1].one;
            noteR.GetComponentInChildren<Text>().text = information[information.Count-1].two;
            
            information.Insert(0,information[information.Count-1]);
            information.RemoveAt(information.Count-1);
        }
    }
    public void Insert(string left, string right, int index)
    {
        information.Add(new Infos(left, right, index));
        if (first)
        {
            noteL.GetComponentInChildren<Text>().text = left;
            noteR.GetComponentInChildren<Text>().text = right;
            first = false;
        }
    }
}
