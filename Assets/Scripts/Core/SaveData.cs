using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int score;
    public int rows;
    public int columns;
    public bool MatchFinished;
    public List<CardSaveEntry> cards = new();
}

[System.Serializable]
public class CardSaveEntry
{
    public int cardId;
    public int siblingIndex;
    public CardState state;
}
