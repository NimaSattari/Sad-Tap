using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [NonSerialized] public Sprite sadImage, happyImage;
    [NonSerialized] public FaceItemPresenter faceItemPresenterPrefab;
    [NonSerialized] public float maxTime;

    public GameObject cardsPanel;
    public GameObject losePanel;
    public GameObject winPanel;
    public List<FaceItemPresenter> cards;
    public Text timeText;
    public Text scoreText;
    public Slider timeSlider;

    private void Start()
    {
        timeSlider.maxValue = maxTime;
    }

    public void SetupCard(int cardID, int sadOrHappy, Action<FaceItemPresenter, int, int> selectingAction)
    {
        FaceItemPresenter faceItemPresenter = InstantiateCard();
        faceItemPresenter.SetCardListenerAndSprite(cardID, sadOrHappy, selectingAction, sadImage, happyImage);
        RotateCards();
    }

    private FaceItemPresenter InstantiateCard()
    {
        var faceItemPresenter = Instantiate(faceItemPresenterPrefab, cardsPanel.transform);
        cards.Add(faceItemPresenter);
        return faceItemPresenter;
    }

    private void RotateCards()
    {
        foreach (FaceItemPresenter card in cards)
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

    public void ResetGame()
    {
        foreach(FaceItemPresenter Card in cards)
        {
            Destroy(Card.gameObject);
        }
        cards.Clear();
    }

    public void Choose(FaceItemPresenter faceItemPresenter, int sadorhappy)
    {
        if (sadorhappy == 0)
        {
            faceItemPresenter.GetComponent<Image>().sprite = happyImage;
        }
        else
        {
            RotateCards();
        }
    }

    public void GameOver()
    {
        losePanel.SetActive(true);
    }

    public void Win()
    {
        winPanel.SetActive(true);
    }

    public void UpdateTimeText(float gameTime)
    {
        timeText.text = gameTime.ToString("0.00");
        timeSlider.value = gameTime;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
