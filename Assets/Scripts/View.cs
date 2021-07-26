using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public Slider timeSlider;
    public float timeToRotateCards;
    public DoTweenActions winAnimator;
    public DoTweenActions loseAnimator;

    public List<FaceItemPresenter> cards;


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
                    card.transform.DORotate(new Vector3(0, 0, 90), timeToRotateCards);
                    break;
                case 1:
                    card.transform.DORotate(new Vector3(0, 0, 180), timeToRotateCards);
                    break;
                case 2:
                    card.transform.DORotate(new Vector3(0, 0, 270), timeToRotateCards);
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
        loseAnimator.DoAnimation();
    }

    public void Win()
    {
        winPanel.SetActive(true);
        winAnimator.DoAnimation();
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
