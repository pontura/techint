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
    Gameplay gamePlay;
    public void SetGamePlay(int levelID)
    {
        foreach (Gameplay g in gameplays)
            g.SetOn(false);

        print("SetGamePlay " + levelID);

        gamePlay = gameplays[levelID];
        gamePlay.SetOn(true);
        string title = GameManager.Instance.settings.GetTitle(levelID);
        SetTutorial(title);
        scoreUI.SetAciveState(levelID);
    }
    public void SetTutorial(string title)
    {
        int delay_to_read_gameTitle = GameManager.Instance.settings.delay_to_read_gameTitle;
        Events.OnSignal(title, delay_to_read_gameTitle, TutorialDone);
    }
    public void TutorialDone()
    {
        gamePlay.InitGame();
        GameManager.Instance.GameTutorialDone();
    }
    public void OnUpdate()
    {
        timerUI.OnUpdate();
    }
}
