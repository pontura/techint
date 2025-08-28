using System;
using UnityEngine;
using YaguarLib.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text[] fields;
    [SerializeField] ProgressBar[] progressBars;
    [SerializeField] float totalTime;
    [SerializeField] float timer = 0;
    bool isOn;

    private void Awake()
    {
        Events.OnWinLevel += OnWinLevel; 
        Events.OnInitLevel += OnInitLevel;
        Events.OnInitPlayingLevel += OnInitPlayingLevel;
    }
    private void OnDestroy()
    {
        Events.OnWinLevel -= OnWinLevel;
        Events.OnInitLevel -= OnInitLevel;
        Events.OnInitPlayingLevel -= OnInitPlayingLevel;
    }
    void OnInitLevel(int levelID)
    {
        Restart();
    }
    private void OnWinLevel(int obj)
    {
        isOn = false;
    }
    void OnInitPlayingLevel()
    {
        if(GameManager.Instance.levelId != 3)
            isOn = true;
    }
    public void Restart()
    {
        this.totalTime = GameManager.Instance.settings.GetTime(GameManager.Instance.levelId);
        timer = totalTime;
        SetField();
    }
    public void OnUpdate()
    {
        if (!isOn) return;
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Events.TimeOver();
            timer = 0;
        }
        SetField();
    }
    void SetField()
    {
        string timeText = YaguarLib.Xtras.Utils.FormatTime(timer);
        foreach (var field in fields)
            field.text = timeText;

        foreach (ProgressBar progressBar in progressBars)
            progressBar.SetValue(timer/ totalTime);
    }
}
