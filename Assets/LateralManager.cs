using System;
using UnityEngine;

public class LateralManager : MonoBehaviour
{
    public int playerID;
    public GameObject[] games;
    public GameObject[] gamevers;

    void Start()
    {
        Events.OnWinLevel += OnWinLevel;
        Events.OnInitLevel += OnInitLevel;
        Events.OnExitLevel += OnExitLevel;
    }
    void OnDestroy()
    {
        Events.OnWinLevel = OnWinLevel;
        Events.OnInitLevel -= OnInitLevel;
        Events.OnExitLevel -= OnExitLevel;
    }
    private void OnInitLevel(int levelID)
    {
        Reset();
        foreach (GameObject go in games) go.SetActive(false);
        games[levelID].SetActive(true);
    }
    private void OnExitLevel()
    {
        Animator anim = gamevers[GameManager.Instance.levelId].GetComponent<Animator>();
        if (anim != null)
            anim.Play("exit");
    }
    private void OnWinLevel(int obj)
    {
        Animator anim = games[GameManager.Instance.levelId].GetComponent<Animator>();
        if (anim != null)
            anim.Play("exit");
        Invoke("OnWinLevelReady", 1);
    }
    private void OnWinLevelReady()
    {
        Reset();
        gamevers[GameManager.Instance.levelId].SetActive(true);
    }
    private void Reset()
    {
        foreach (GameObject go in games) go.SetActive(false);
        foreach (GameObject go in gamevers) go.SetActive(false);
    }
}
