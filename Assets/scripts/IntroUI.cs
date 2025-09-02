using UnityEngine;

public class IntroUI : ButtonLidar
{
    [SerializeField] TMPro.TMP_Text title;
    [SerializeField] TMPro.TMP_Text field;
    [SerializeField] Animator textAnim;

    int _index;

    public override void OnClicked()
    {
        print("OnClicked");
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.CLICK_NEUTRAL,YaguarLib.Audio.AudioManager.channels.UI);
        if (_index < GameManager.Instance.settings.intro_texts.Length) {
            textAnim.Play("introTextEntry", 0, 0);
            title.text = GameManager.Instance.settings.intro_texts[_index];
            _index++;
        } else {
            GameManager.Instance.InitGame();            
            title.text = GameManager.Instance.settings.intro_texts[0];
            _index = 1;
        }

    }
    public void Init()
    {
        title.text = GameManager.Instance.settings.intro_texts[_index];
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.SIGNAL_ENTRY, YaguarLib.Audio.AudioManager.channels.GAME);
        _index++;
    }
}
