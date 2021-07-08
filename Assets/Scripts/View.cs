using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Sprite SadImage, HappyImage;
    public GameObject ButtonPrefab;
    public GameObject gamepanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public List<GameObject> Cards;

    public void SetImage(int CardID, int SadOrHappy, Action<GameObject, int, int> SelectingAction)
    {
        GameObject button = Instantiate(ButtonPrefab, gamepanel.transform);
        Cards.Add(button);
        if (SadOrHappy == 0)
        {
            button.GetComponent<Image>().sprite = SadImage;
            button.GetComponent<Button>().onClick.AddListener(() => SelectingAction(button, CardID, SadOrHappy));
        }
        else if (SadOrHappy == 1)
        {
            button.GetComponent<Image>().sprite = HappyImage;
            button.GetComponent<Button>().onClick.AddListener(() => SelectingAction(button, CardID, SadOrHappy));
        }
        RotateCards();
    }

    public void Choose(GameObject button, int sadorhappy)
    {
        if (sadorhappy == 0)
        {
            button.GetComponent<Image>().sprite = HappyImage;
        }
        else
        {
            RotateCards();
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void Win()
    {
        winPanel.SetActive(true);
    }
    private void RotateCards()
    {
        foreach (GameObject card in Cards)
        {
            int randomNumber = UnityEngine.Random.Range(0, 3);
            switch (randomNumber)
            {
                case 0:
                    card.transform.Rotate(new Vector3(0, 0, 90));
                    break;
                case 1:
                    card.transform.Rotate(new Vector3(0, 0, 180));
                    break;
                case 2:
                    card.transform.Rotate(new Vector3(0, 0, 270));
                    break;
                default:
                    break;
            }
        }
    }
}
