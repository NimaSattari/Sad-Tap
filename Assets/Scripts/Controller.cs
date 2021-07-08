using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Config config;
    [SerializeField] View view;
    private float nextUpdate = 0.01f;
    Model model = new Model();

    void Start()
    {
        model.SettingDifficulty(config.DataList.HowManyCards, config.DataList.PercentageOfSadCards, config.DataList.GameTime);
        model.GenerateAllCards();
        model.GenerateSadCards();

        view.SadImage = config.Sadsprite;
        view.HappyImage = config.Happysprite;
        view.ButtonPrefab = config.buttonPrefab;
        view.gamepanel = config.GamePanel;
        view.gameOverPanel = config.GameOverPanel;
        view.winPanel = config.WinPanel;
        view.timeText = config.TimeText;


        foreach (int i in model.AllCards)
        {
            if (model.SadCards[i] == false)
            {
                view.SetImage(i, 0, SelectCard);
            }
            else if (model.SadCards[i] == true)
            {
                view.SetImage(i, 1, SelectCard);
            }
        }
    }

    public void SelectCard(GameObject button, int CardID,int sadorhappy)
    {
        model.Check(CardID);
        view.Choose(button, sadorhappy);
        CheckIfWin();
    }

    private void CheckIfWin()
    {
        if (model.CheckIfDone())
        {
            view.Win();
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
    private void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Time.time + 0.01f;
            ShowTime();
            CheckTimeIsUp();
        }
    }
}
