using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameplayManager gameplayManager;
    
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
        gameplayManager.Init(levelID);
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
        gameplayManager.InitGame();
        GameManager.Instance.GameTutorialDone();
    }
    public void OnUpdate()
    {
        timerUI.OnUpdate();
    }
}
