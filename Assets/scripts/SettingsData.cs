using System;
using Unity.VisualScripting;
using UnityEngine.Rendering.LookDev;

[Serializable]
public class SettingsData
{
    public int time_game_1;
    public int time_game_2;
    public int time_game_3;


    public string intro_title;

    public string gameEnd_win;
    public string gameEnd_lose;
    public int timeForSummary;

    public string level_1_title;
    public string level_2_title;
    public string level_3_title;
    public string timeOver;
    public int delay_to_read_gameTitle;
    public int timeOverDuration;

    public int winDuration;
    public string win;
    public string lose;

    public string slot1;
    public string slot2; 
    public string slot3;
    public string slot4;
    public string slot5;
    public string slot6;
    public string slot7;

    public string GetSlotText(int id)
    {
        switch(id)
        {
            case 1: return slot1;
            case 2: return slot2;
            case 3: return slot3;
            case 4: return slot4;
            case 5: return slot5;
            case 6: return slot6;
            case 7: return slot7;
        }
        return "";
    }

    public float triviaSpeed;
    public TriviaData[] trivias;

    [Serializable]
    public class TriviaData
    {
        public string trivia;
        public int trivia_valor;
        public int trivia_valor_inicial;
        public int trivia_valor_add;
    }


    public int GetTime(int levelID)
    {
        switch (levelID)
        {
            case 0: return time_game_1;
            case 1: return time_game_2;
            default: return time_game_3;
        }
    }
    public string GetTitle(int levelID)
    {
        switch (levelID)
        {
            case 0: return level_1_title;
            case 1: return level_2_title;
            default: return level_3_title;
        }
    }
    public string GetResult(bool _win)
    {
        if (_win) return win;
        else return lose;
    }
}