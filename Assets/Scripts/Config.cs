using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DifficultyData
{
    public int HowManyCards;
    public int PercentageOfSadCards;
    public int GameTime;
}

public class Config : MonoBehaviour
{
    public DifficultyData DataList;
    public Sprite Happysprite, Sadsprite;
    public GameObject buttonPrefab;
    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public Text TimeText;
}