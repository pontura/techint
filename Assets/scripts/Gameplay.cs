using System;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    bool win;
    private void Awake()
    {
        Events.OnWinLevel += OnWinLevel;
        Events.OnExitLevel += OnExitLevel;
    }
    private void OnDestroy()
    {
        Events.OnWinLevel -= OnWinLevel;
        Events.OnExitLevel -= OnExitLevel;
    }

    private void OnWinLevel(int _playerID)
    {
        if (playerID == _playerID) 
            Win();
        else
            Lose();
    }

    public int playerID = 1;
    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }    
    public virtual void InitGame()
    {        
        Debug.Log("init");
    }
    public void Win()
    {        
        win = true;
        if (GetComponent<Animator>() != null)
            GetComponent<Animator>().Play("Win");
    }
    public void Lose()
    {
        win = false;
        if (GetComponent<Animator>() != null)
            GetComponent<Animator>().Play("Lose");
    }
    void OnExitLevel()
    {
        if (win && GetComponent<Animator>() != null)
            GetComponent<Animator>().Play("Exit");
    }

    public void PlayGameEntrySfx() {
        Debug.Log("#PlayGameEntrySfx");
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.GAME_ENTRY, YaguarLib.Audio.AudioManager.channels.GAME);
    }

    public void PlayGameWinSfx() {
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.GAME_WIN, YaguarLib.Audio.AudioManager.channels.GAME);
    }
}
