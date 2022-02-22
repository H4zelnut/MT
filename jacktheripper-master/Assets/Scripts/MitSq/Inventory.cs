using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool boss, saucy, hell, news;
    public GameObject dB, sJ, fH, paper, news1, news2;
    // Start is called before the first frame update
    void Start()
    {
        boss = saucy = news = false;
    }
    public void DearBoss()
    {
        if (boss)
        {
            dB.SetActive(true);
            boss = false;
        }
        else
        {
            dB.SetActive(false);
            boss = true;
        }
    }
    public void SaucyJack()
    {
        if (saucy)
        {
            sJ.SetActive(true);
            saucy = false;
        }
        else
        {
            sJ.SetActive(false);
            saucy = true;
        }
    }
    public void FromHell()
    {
        if (hell)
        {
            fH.SetActive(true);
            hell = false;
        }
        else
        {
            fH.SetActive(false);
            hell = true;
        }
    }
    public void Newspaper()
    {
        if (news)
        {
            paper.SetActive(true);
            news1.SetActive(true);
            news2.SetActive(true);
            news = false;
        }
        else
        {
            paper.SetActive(false);
            news1.SetActive(false);
            news2.SetActive(false);
            news = true;
        }
    }
}
