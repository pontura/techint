using UnityEngine;

public class IntroUI : ButtonLidar
{
    [SerializeField] TMPro.TMP_Text title;
    [SerializeField] TMPro.TMP_Text field;

    public override void OnClicked()
    {
        print("OnClicked");
        GameManager.Instance.InitGame();
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.CLICK_NEUTRAL,YaguarLib.Audio.AudioManager.channels.UI);
    }
    public void Init()
    {
        title.text = GameManager.Instance.settings.intro_title;
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.SIGNAL_ENTRY, YaguarLib.Audio.AudioManager.channels.GAME);
    }
}
