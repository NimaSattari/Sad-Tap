using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}