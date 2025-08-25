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
    }
    void OnDestroy()
    {
        Events.OnWinLevel = OnWinLevel;
        Events.OnInitLevel -= OnInitLevel;
    }
    private void OnInitLevel(int levelID)
    {
        Reset();
        foreach (GameObject go in games) go.SetActive(false);
        games[levelID].SetActive(true);
    }
    private void OnWinLevel(int obj)
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
