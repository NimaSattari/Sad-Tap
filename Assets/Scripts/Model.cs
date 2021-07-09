using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public List<int> AllCards = new List<int>();
    public List<bool> SadCards = new List<bool>();
    public int HowManyCards = 10;
    public int PercentageOfSadCards = 50;
    public float GameTime = 10;
    public float NowTime;

    public void SettingDifficulty(int howmanycards, int percentageofsadcards, int gametime)
    {
        HowManyCards = howmanycards;
        PercentageOfSadCards = percentageofsadcards;
        GameTime = gametime;
        NowTime = gametime;
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
            if (NowTime > GameTime)
            {
                NowTime = GameTime;
            }
        }
        else
        {
            ChangeTime(-2);
        }
    }

    private void ChangeTime(int timeToChange)
    {
        NowTime += timeToChange;
    }
    public bool CheckTime()
    {
        if (NowTime <= 0)
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
    public float GetTime()
    {
        return NowTime;
    }
    public void SetTime()
    {
        NowTime -= 0.01f;
        if (NowTime < 0)
        {
            NowTime = 0;
        }
    }
}
