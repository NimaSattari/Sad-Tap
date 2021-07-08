using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public List<int> AllCards = new List<int>();
    public List<bool> SadCards = new List<bool>();
    public int HowManyCards = 10;
    public int PercentageOfSadCards = 50;
    public int GameTime = 10;
    bool isTimeUp;

    public void SettingDifficulty(int howmanycards, int percentageofsadcards, int gametime)
    {
        HowManyCards = howmanycards;
        PercentageOfSadCards = percentageofsadcards;
        GameTime = gametime;
    }

    public void GenerateAllCards()
    {
        for (int i = 0; i < HowManyCards; i++)
        {
            AllCards.Add(i);
        }
    }
    public void GenerateSadCards()
    {
        for (int i = 0; i < AllCards.Count; i++)
        {
            SadCards.Add(true);
        }
        for (int i = 0; i < AllCards.Count; i++)
        {
            int randomnumber = Random.Range(0, 100);
            if (randomnumber <= PercentageOfSadCards)
            {
                SadCards[i] = false;
            }
            else
            {
                SadCards[i] = true;
            }
        }
    }

    public void Check(int CardID)
    {
        if (SadCards[AllCards[CardID]] == false)
        {
            SadCards[AllCards[CardID]] = true;
            ChangeTime(+1);
        }
        else
        {
            ChangeTime(-2);
        }
    }

    private void ChangeTime(int timeToChange)
    {
        GameTime += timeToChange;
    }
    public bool CheckTime()
    {
        if (GameTime <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckIfDone()
    {
        for (int i = 0; i < SadCards.Count; i++)
        {
            if (SadCards[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
