using UnityEngine;
using YaguarLib.Audio;

public static class Events
{

    //Audio
    public static System.Action<string, int, System.Action> OnSignal = delegate { };
    public static System.Action<string, int, System.Action> OnSignalRefresh = delegate { };
    public static System.Action<string, int, int, System.Action> OnSignalByPlayer = delegate { };
    public static System.Action<int> OnWinLevel = delegate { };
    public static System.Action OnExitLevel = delegate { };
    public static System.Action<int> OnInitLevel = delegate { };
    public static System.Action OnInitPlayingLevel = delegate { };
    public static System.Action TimeOver = delegate { };
    public static System.Action CalibrationDone = delegate { };
    public static System.Action<int> LevelComplete = delegate { };
    public static System.Action OnPipeRotate = delegate { };
    public static System.Action<bool> PhotoOpportunityShow = delegate { };
}