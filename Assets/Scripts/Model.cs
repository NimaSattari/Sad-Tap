using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public List<int> allCards = new List<int>();
    public List<bool> sadCards = new List<bool>();
    public int howManyCards = 10;
    public int percentageOfSadCards = 50;
    public float gameTime = 10;
    public float nowTime;

    public void SettingDifficulty(int howmanycards, int percentageofsadcards, int gametime)
    {
        howManyCards = howmanycards;
        percentageOfSadCards = percentageofsadcards;
        gameTime = gametime;
        nowTime = gametime;
    }

    public void GenerateAllCards()
    {
        for (int i = 0; i < howManyCards; i++)
        {
            allCards.Add(i);
        }
    }

    public void GenerateSadCards()
    {
        for (int i = 0; i < allCards.Count; i++)
        {
            sadCards.Add(true);
        }
        for (int i = 0; i < allCards.Count; i++)
        {
            int randomnumber = Random.Range(0, 100);
            if (randomnumber <= percentageOfSadCards)
            {
                sadCards[i] = false;
            }
            else
            {
                sadCards[i] = true;
            }
        }
    }

    public void Check(int CardID)
    {
        if (sadCards[allCards[CardID]] == false)
        {
            sadCards[allCards[CardID]] = true;
            ChangeTime(+0.5f);
            if (nowTime > gameTime)
            {
                nowTime = gameTime;
            }
        }
        else
        {
            ChangeTime(-2);
        }
    }

    private void ChangeTime(float timeToChange)
    {
        nowTime += timeToChange;
    }

    public bool CheckTime()
    {
        if (nowTime <= 0)
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
        for (int i = 0; i < sadCards.Count; i++)
        {
            if (sadCards[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public float GetTime()
    {
        return nowTime;
    }

    public void SetTime()
    {
        nowTime -= 0.01f;
        if (nowTime < 0)
        {
            nowTime = 0;
        }
    }
}
