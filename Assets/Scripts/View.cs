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

    [Header("Card Rotation Animation Values")]
    public float timeToRotateCards;

    [Header("Win Animation Values")]
    [SerializeField] Vector3 wintargetLocation = Vector3.zero;
    [SerializeField] Vector3 wintargetRotation = Vector3.zero;
    [SerializeField] float winanimationDuration = 1f;
    [SerializeField] Ease winanimationEase = Ease.Linear;

    [Header("Lose Animation Values")]
    [SerializeField] Vector3 losetargetLocation = Vector3.zero;
    [SerializeField] Vector3 losetargetSize = Vector3.zero;
    [SerializeField] float loseanimationDuration = 1f;
    [SerializeField] Ease loseanimationEase = Ease.Linear;

    [Header("Cards List")]
    public List<FaceItemPresenter> cards;

    [SerializeField] DoTweenActions actions;


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
        LoseDoTweenMoveAndScale();
    }

    public void Win()
    {
        winPanel.SetActive(true);
        WinDoTweenMoveAndRotate();
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

    public void LoseDoTweenMoveAndScale()
    {
        DOTween.Sequence().SetAutoKill(false)
    .Append(losePanel.transform.DOLocalMove(losetargetLocation, loseanimationDuration).SetEase(loseanimationEase))
    .Join(losePanel.transform.DOScale(losetargetSize, loseanimationDuration).SetEase(loseanimationEase));
    }

    public void WinDoTweenMoveAndRotate()
    {
        DOTween.Sequence().SetAutoKill(false)
    .Append(winPanel.transform.DOLocalMove(wintargetLocation, winanimationDuration).SetEase(winanimationEase))
    .Join(winPanel.transform.DORotate(wintargetRotation, winanimationDuration).SetEase(winanimationEase));
    }
}
