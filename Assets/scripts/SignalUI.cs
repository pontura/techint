using UnityEngine;

public class SignalUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text field;

    public void SetState(string text = "")
    {
        field.text = text;
        gameObject.SetActive(true);
    }

    public void PlaySignalSfx() {
        Debug.Log("#PlaySignalSfx");
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.SIGNAL_ENTRY, YaguarLib.Audio.AudioManager.channels.UI);
    }
}
