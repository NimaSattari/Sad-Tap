using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerView : MonoBehaviour
{
    public Sprite SadImage, HappyImage;
    public GameObject ButtonPrefab;

    public void SetImage(int SadOrHappy)
    {
        GameObject button = Instantiate(ButtonPrefab, FindObjectOfType<Canvas>().transform);
        if (SadOrHappy == 0)
        {
            button.GetComponent<Image>().sprite = SadImage;
            //button.GetComponent<Button>().onClick.AddListener(() => Choose(button, 0));
        }
        else
        {
            button.GetComponent<Image>().sprite = HappyImage;
            //button.GetComponent<Button>().onClick.AddListener(() => Choose(button, 1));
        }
    }
    public void Choose(GameObject button, int sadorhappy)
    {
        if (sadorhappy == 0)
        {
            button.GetComponent<Image>().sprite = HappyImage;
        }
        else
        {
            
        }
    }
}
