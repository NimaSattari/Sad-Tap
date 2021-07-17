using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Model
{
    public List<int> allCards = new List<int>();
    public List<bool> sadCards = new List<bool>();

    public int cardsCountStart = 4;
    public int roundsOfOneCardsCount = 5;
    public int addedCardsToCount = 4;

    public int percentageOfSadCards = 50;
    public float gameTime = 10;
    public float nowTime;

    int roundCounter = 0;
    int score;

    public void SettingDifficulty(int cardsCountStartValue, int percentageOfSadCardsValue, int gameTimeValue, int roundsOfOneCardsCountValue, int addedCardsToCountValue)
    {
        cardsCountStart = cardsCountStartValue;
        roundsOfOneCardsCount = roundsOfOneCardsCountValue;
        addedCardsToCount = addedCardsToCountValue;
        percentageOfSadCards = percentageOfSadCardsValue;
        gameTime = gameTimeValue;
        nowTime = gameTimeValue;
    }

    public void GenerateAllCards()
    {
        ResetCards();
        float counter = roundCounter / roundsOfOneCardsCount;
        int addedCards = 1 * (int)counter;
        for (int i = 0; i < cardsCountStart + (addedCards * addedCardsToCount); i++)
        {
            allCards.Add(i);
        }
        if (allCards.Count < 24)
        {
            roundCounter++;
        }
    }

    public void GenerateSadCards()
    {
        for (int i = 0; i < allCards.Count; i++)
        {
            sadCards.Add(true);
        }
        int countSadCards = 0;
        for (int i = 0; i < sadCards.Count; i++)
        {
            countSadCards++;
            if ((float)countSadCards / (float)sadCards.Count * 100 <= percentageOfSadCards)
            {
                sadCards[i] = false;
            }
        }
        sadCards = sadCards.OrderBy(i => Guid.NewGuid()).ToList();

    }

    public void ResetCards()
    {
        allCards.Clear();
        sadCards.Clear();
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
        score++;
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

    public int GetScore()
    {
        return score;
    }
}
