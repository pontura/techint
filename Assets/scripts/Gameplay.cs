using System;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private void Awake()
    {
        Events.OnWinLevel += OnWinLevel;
    }
    private void OnDestroy()
    {
        Events.OnWinLevel -= OnWinLevel;
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
        if(GetComponent<Animator>() != null)
            GetComponent<Animator>().Play("Win");
    }
    public void Lose()
    {
        if (GetComponent<Animator>() != null)
            GetComponent<Animator>().Play("Lose");
    }
}
