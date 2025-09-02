using System;
using Unity.VisualScripting;
using UnityEngine.Rendering.LookDev;

[Serializable]
public class SettingsData
{
    public float click_delay_filter;
    public int time_game_1;
    public int time_game_2;
    public int time_game_3;

    public string ip;

    public string intro_title;

    public string gameEnd_win;
    public string gameEnd_lose;
    public string gameEnd_draw;

    public int timeForSummary;

    public string[] intro_texts;

    public string[] level_1_title;
    public string[] level_2_title;
    public string[] level_3_title;    

    public string[] level_1_laterals_win;
    public string[] level_2_laterals_win;
    public string[] level_3_laterals_win;

    public string[] level_3_laterals;

    public string timeOver;
    public int delay_to_read_gameTitle;
    public int timeOverDuration;

    public int winDuration;
    public int winSignalsDelay;
    public string[] win;
    public string[] lose;

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
    public string[] GetTitle(int levelID)
    {
        switch (levelID)
        {
            case 0: return level_1_title;
            case 1: return level_2_title;
            case 2: return level_3_title;
        }
        return null;
    }
    public string GetResult(bool _win)
    {
        if (_win) return win[GameManager.Instance.levelId];
        else return lose[GameManager.Instance.levelId];
    }
    public string[] GetLateralTextWin(int levelID)
    {
        switch (levelID)
        {
            case 0: return (string[])level_1_laterals_win.Clone();
            case 1: return (string[])level_2_laterals_win.Clone();
            case 2: return (string[])level_3_laterals_win.Clone();
        }
        return null;
    }

    public string[] GetLateralText(int levelID) {
        switch (levelID) {
            case 0: return null;
            case 1: return null;
            case 2: return (string[])level_3_laterals.Clone();
        }
        return null;
    }
}