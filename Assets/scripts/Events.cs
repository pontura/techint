using UnityEngine;
using YaguarLib.Audio;

public static class Events
{

    //Audio
    public static System.Action<int> OnWinLevel = delegate { };
    public static System.Action TimeOver = delegate { };
    public static System.Action CalibrationDone = delegate { };
    public static System.Action<int> LevelComplete = delegate { };
}