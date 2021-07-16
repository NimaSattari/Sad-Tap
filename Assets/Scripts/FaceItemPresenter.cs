using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceItemPresenter : MonoBehaviour
{
    public Button itemButton;
    public Image itemImage;

    public void SetCardListenerAndSprite(int cardID, int sadOrHappy, Action<FaceItemPresenter, int, int> selectingAction, Sprite sadImage, Sprite happyImage)
    {
        if (sadOrHappy == 0)
        {
            itemImage.sprite = sadImage;
            itemButton.onClick.AddListener(() => selectingAction(this, cardID, sadOrHappy));
        }
        else if (sadOrHappy == 1)
        {
            itemImage.sprite = happyImage;
            itemButton.onClick.AddListener(() => selectingAction(this, cardID, sadOrHappy));
        }
    }
}
