using System;

[Serializable]
public class SettingsData
{
    public int time_game_1;
    public int time_game_2;
    public int time_game_3;
    public string intro_title;
    public string level_1_title;
    public string level_2_title;
    public string level_3_title;
    public string timeOver;
    public int delay_to_read_gameTitle;
    public int timeOverDuration;

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
}