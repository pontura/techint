using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] LevelSignal[] player1;
    [SerializeField] LevelSignal[] player2;
    GameManager manager;

    private void Awake()
    {
        Events.OnWinLevel += OnWinLevel;
        Restart();
    }
    private void OnDestrot()
    {
        Events.OnWinLevel -= OnWinLevel;
    }
    private void OnWinLevel(int playerID)
    {
        int levelID = manager.levelId;
        if(playerID == 1)
        {
            player1[levelID].SetState(LevelSignal.states.win);
            player2[levelID].SetState(LevelSignal.states.lose);
        }
        else
        {
            player1[levelID].SetState(LevelSignal.states.lose);
            player2[levelID].SetState(LevelSignal.states.win);
        }
    }

    public void Restart()
    {
        foreach(var ls in player1)
            ls.SetState(LevelSignal.states.idle);

        foreach (var ls in player2)
            ls.SetState(LevelSignal.states.idle);
    }
    public void SetAciveState(int levelID)
    {
        player1[levelID].SetState(LevelSignal.states.current);
        player2[levelID].SetState(LevelSignal.states.current);
    }
}
