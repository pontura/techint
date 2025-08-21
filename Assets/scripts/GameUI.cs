using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] Gameplay[] gameplays;
    
    ScoreUI scoreUI;
    TimerUI timerUI;

    public void Init()
    {
        scoreUI = GetComponent<ScoreUI>();
        timerUI = GetComponent<TimerUI>();
    }
    public void Restart()
    {
        scoreUI.Restart();
        timerUI.Restart();
        SetGamePlay(0);
    }
    public void SetGamePlay(int levelID)
    {
        foreach (Gameplay g in gameplays)
            g.SetOff();
        gameplays[levelID].SetOn();
        scoreUI.SetAciveState(levelID);
    }
    public void OnUpdate()
    {
        timerUI.OnUpdate();
    }
}
