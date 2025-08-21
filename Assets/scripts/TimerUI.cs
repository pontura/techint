using UnityEngine;
using YaguarLib.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text[] fields;
    [SerializeField] ProgressBar[] progressBars;
    [SerializeField] float totalTime;
    [SerializeField] float timer = 0;

    public void Restart()
    {
        this.totalTime = GameManager.Instance.settings.GetTime(GameManager.Instance.levelId);
        timer = totalTime;
        SetField();
    }
    public void OnUpdate()
    {
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
        foreach (var field in fields)
            field.text = YaguarLib.Xtras.Utils.FormatTime(timer);

        foreach (ProgressBar progressBar in progressBars)
            progressBar.SetValue(timer/ totalTime);
    }
}
