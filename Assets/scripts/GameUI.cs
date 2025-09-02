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
        if (levelID<3)
        {
            SetTutorial(levelID);
            scoreUI.SetAciveState(levelID);
        }
        else
            TutorialDone();
    }
    int titleIndex;
    public void SetTutorial(int levelID, bool isRefresh=false)
    {
        string[] title = GameManager.Instance.settings.GetTitle(levelID);
        int delay_to_read_gameTitle = GameManager.Instance.settings.delay_to_read_gameTitle;
        Debug.Log("SetTutorial: " + levelID + " " + titleIndex);
        System.Action doNext = titleIndex < title.Length-1 ?
            () => {
                titleIndex++;
                SetTutorial(levelID,true);
            } :
            () => {
                titleIndex = 0;
                TutorialDone();
            };
        if(isRefresh)
            Events.OnSignalRefresh(title[titleIndex], delay_to_read_gameTitle, doNext);
        else
            Events.OnSignal(title[titleIndex], delay_to_read_gameTitle, doNext);
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
