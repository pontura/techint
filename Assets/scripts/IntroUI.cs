using UnityEngine;

public class IntroUI : ButtonLidar
{
    [SerializeField] TMPro.TMP_Text title;
    [SerializeField] TMPro.TMP_Text field;
    [SerializeField] Animator textAnim;

    int _index;

    [SerializeField] bool _lock;

    private void Start() {
        Events.PhotoOpportunityShow += Show;
    }

    private void OnDestroy() {
        Events.PhotoOpportunityShow -= Show;
    }

    void Show(bool enable) {
        gameObject.SetActive(!enable);
    }

    private void OnEnable() {
        Reset();
    }

    public override void OnClicked()
    {
        print("OnClicked");
        if (_lock || !gameObject.activeSelf)
                return;
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.CLICK_NEUTRAL,YaguarLib.Audio.AudioManager.channels.UI);
        if (_index < GameManager.Instance.settings.intro_texts.Length) {
            Events.OnClickTimerSet((state) => _lock = state);
            textAnim.Play("introTextEntry", 0, 0);
            title.text = GameManager.Instance.settings.intro_texts[_index];
            _index++;
            GameManager.Instance.PlayVoiceOver("intro_"+_index);
        } else {
            GameManager.Instance.InitGame();
        }

    }

    void Reset() {
        if (GameManager.Instance!=null) {
            title.text = GameManager.Instance.settings.intro_texts[0];
            _index = 1;
            GameManager.Instance.PlayVoiceOver("intro_" + _index);
            Events.OnClickTimerSet((state) => _lock = state);
        }
    }

    public void Init()
    {
        Debug.Log("#Intro Init");
        title.text = GameManager.Instance.settings.intro_texts[_index];
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.SIGNAL_ENTRY, YaguarLib.Audio.AudioManager.channels.GAME);
        _index++;
        GameManager.Instance.PlayVoiceOver("intro_" + _index);
        Events.OnClickTimerSet((state) => _lock = state);
    }
}
