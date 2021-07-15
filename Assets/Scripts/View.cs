using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [NonSerialized] public Sprite sadImage, happyImage;
    [NonSerialized] public FaceItemPresenter faceItemPresenterPrefab;
    public GameObject gamepanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public List<GameObject> cards;
    public Text timeText;

    public void SetupCard(int cardID, int sadOrHappy, Action<GameObject, int, int> selectingAction)
    {
        FaceItemPresenter faceItemPresenter = InstantiateCard();
        SetCardListenerAndSprite(cardID, sadOrHappy, selectingAction, faceItemPresenter);
        RotateCards();
    }

    private FaceItemPresenter InstantiateCard()
    {
        var faceItemPresenter = Instantiate(faceItemPresenterPrefab, gamepanel.transform);
        cards.Add(faceItemPresenter.gameObject);
        return faceItemPresenter;
    }

    private void SetCardListenerAndSprite(int cardID, int sadOrHappy, Action<GameObject, int, int> selectingAction, FaceItemPresenter faceItemPresenter)
    {
        if (sadOrHappy == 0)
        {
            faceItemPresenter.itemImage.sprite = sadImage;
            faceItemPresenter.itemButton.onClick.AddListener(() => selectingAction(faceItemPresenter.gameObject, cardID, sadOrHappy));
        }
        else if (sadOrHappy == 1)
        {
            faceItemPresenter.itemImage.sprite = happyImage;
            faceItemPresenter.itemButton.onClick.AddListener(() => selectingAction(faceItemPresenter.gameObject, cardID, sadOrHappy));
        }
    }

    private void RotateCards()
    {
        foreach (GameObject card in cards)
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
        foreach(GameObject Card in cards)
        {
            Destroy(Card);
        }
        cards.Clear();
    }

    public void Choose(GameObject button, int sadorhappy)
    {
        if (sadorhappy == 0)
        {
            button.GetComponent<Image>().sprite = happyImage;
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

    public void UpdateTimeText(float gameTime)
    {
        timeText.text = gameTime.ToString("0.00");
    }
}
