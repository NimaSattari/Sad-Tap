using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Config config;
    [SerializeField] View view;
    private float nextUpdate = 0.01f;
    Model model;

    void Start()
    {
        SetupValues();
        model = new Model();
        MakeNewGame();
    }

    private void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Time.time + 0.01f;
            ShowTime();
            CheckTimeIsUp();
        }
    }

    private void SetupValues()
    {
        view.sadImage = config.sadsprite;
        view.happyImage = config.happysprite;
        view.faceItemPresenterPrefab = config.faceItemPresenterPrefab;
        view.maxTime = config.dataList.gameTime;
    }

    public void MakeNewGame()
    {
        model.SettingDifficulty(config.dataList.cardsCountStart, config.dataList.percentageOfSadCards, config.dataList.gameTime, config.dataList.roundsOfOneCardsCount, config.dataList.addedCardsToCount);
        model.GenerateAllCards();
        model.GenerateSadCards();
        view.ResetGame();
        foreach (int i in model.allCards)
        {
            if (model.sadCards[i] == false)
            {
                view.SetupCard(i, 0, SelectCard);
            }
            else if (model.sadCards[i] == true)
            {
                view.SetupCard(i, 1, SelectCard);
            }
        }
    }

    public void SelectCard(FaceItemPresenter faceItemPresenter, int CardID,int sadorhappy)
    {
        model.Check(CardID);
        view.Choose(faceItemPresenter, sadorhappy);
        CheckIfWin();
    }

    private void CheckIfWin()
    {
        if (model.CheckIfDone())
        {
            MakeNewGame();
            view.UpdateScoreText(model.GetScore());
        }
    }

    private void CheckTimeIsUp()
    {
        if (model.CheckTime())
        {
            view.GameOver();
        }
    }

    private void ShowTime()
    {
        model.SetTime();
        view.UpdateTimeText(model.GetTime());
    }
}
