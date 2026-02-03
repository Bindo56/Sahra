using System;
using System.Collections;


public static class GameEvents
{
    public static Action<CardView> RequestCardFlip;
    public static Action<CardView> CardRevealed;
    public static Action<bool> MatchResolved;
    public static Action HideMenu;
    public static Action ShowMenu;
    public static Action GameOverCheck;
    public static Action GameOver;

}
