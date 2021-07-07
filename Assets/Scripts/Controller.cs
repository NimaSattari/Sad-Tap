using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Config config;
    [SerializeField] View view;
    void Start()
    {
        Model model = new Model();

        model.SettingDifficulty(config.DataList.HowManyCards, config.DataList.PercentageOfSadCards, config.DataList.GameTime);
        model.GenerateAllCards();
        model.GenerateSadCards();

        view.SadImage = config.Sadsprite;
        view.HappyImage = config.Happysprite;
        view.ButtonPrefab = config.buttonPrefab;

        foreach (int i in model.SadCards)
        {
            if (model.SadCards[i] == 0)
            {
                view.SetImage(0);
            }
            else
            {
                view.SetImage(1);
            }
        }
    }

    void Update()
    {
        
    }
}
