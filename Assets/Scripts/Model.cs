using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public List<int> AllCards = new List<int>();
    public List<int> SadCards = new List<int>();
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
        for (int i = 0; i <= HowManyCards; i++)
        {
            AllCards.Add(i);
        }
    }
    public void GenerateSadCards()
    {
        for (int i = 0; i <= AllCards.Count; i++)
        {
            SadCards.Add(0);
        }
        for (int i = 0; i <= AllCards.Count; i++)
        {
            int randomnumber = Random.Range(0, 100);
            if (randomnumber <= PercentageOfSadCards)
            {
                SadCards[i] = 0;
            }
            else
            {
                SadCards[i] = 1;
            }
        }
    }

    public void Check(int CardID)
    {
        if (SadCards[AllCards[CardID]] == 0)
        {
            SadCards[AllCards[CardID]] = 1;
            ChangeTime(+1);
        }
        else
        {
            ChangeTime(-2);
        }
    }

    public void ChangeTime(int timeToChange)
    {
        GameTime += timeToChange;
        CheckTime();
    }
    private void CheckTime()
    {
        if (GameTime <= 0)
        {
            isTimeUp = true;
        }
    }

    public bool IsTimeUp()
    {
        return isTimeUp;
    }
}
