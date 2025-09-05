using System;
using UnityEngine;
using YaguarLib.UI;

public class ClickTimerUI : MonoBehaviour
{
    [SerializeField] GameObject container;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] float timer = 0;
    bool isOn;

    System.Action<bool> SetState;

    private void Awake()
    {
        Events.OnClickTimerSet += OnClickTimerSet;
    }
    private void OnDestroy()
    {
        Events.OnClickTimerSet -= OnClickTimerSet;
    }
    public void OnClickTimerSet(System.Action<bool> setState)
    {        
        timer = GameManager.Instance.settings.click_timer;
        isOn = true;        
        if(SetState!=null)
            SetState(false);
        SetState = setState;
        SetState(isOn);
        container.SetActive(isOn);
        SetField();
    }
    void Update()
    {
        if (!isOn) return;
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            isOn = false;
            container.SetActive(isOn);
            timer = 0;
            SetState(isOn);
        }
        SetField();
    }
    void SetField()
    {   
        progressBar.SetValue(timer/ GameManager.Instance.settings.click_timer);
    }
}
