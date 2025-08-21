using UnityEngine;
using YaguarLib.UI;
using static UnityEngine.Rendering.DebugUI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text field;
    [SerializeField] TMPro.TMP_Text field2;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] float totalTime;
    [SerializeField] float timer = 0;

    public void Restart()
    {
        this.totalTime = GameManager.Instance.settings.totalTime;
        timer = totalTime;
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
        field.text = YaguarLib.Xtras.Utils.FormatTime(timer);
        field2.text = YaguarLib.Xtras.Utils.FormatTime(timer);

        progressBar.SetValue(timer/ totalTime);
    }
}
