using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DifficultyData
{
    public int cardsCountStart;
    public int roundsOfOneCardsCount;
    public int addedCardsToCount;
    public int percentageOfSadCards;
    public int gameTime;
}

[CreateAssetMenu(fileName = "SadTap", menuName = "Config", order = 1)]
public class Config : ScriptableObject
{
    public DifficultyData dataList;
    public Sprite happysprite, sadsprite;
    public FaceItemPresenter faceItemPresenterPrefab;
}