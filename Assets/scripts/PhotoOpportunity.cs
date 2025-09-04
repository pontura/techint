using UnityEngine;
using UnityEngine.Video;

public class PhotoOpportunity : ButtonLidar
{
    [SerializeField] VideoPlayer video;
    [SerializeField] Animator anim;

    private void Awake() {
        Events.PhotoOpportunityShow += Show;

    }

    private void Start() {
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        Events.PhotoOpportunityShow -= Show;
    }

    public void Show(bool enable) {
        Debug.Log("#Show: " + enable);
        gameObject.SetActive(enable);
        string animName = enable ? "Entry" : "Exit";
        anim.Play(animName, 0, 0);
        if (enable) {
            YaguarLib.Audio.AudioManager.Instance.PlaySound(YaguarLib.Audio.AudioManager.Instance.GetAudio(YaguarLib.Audio.AudioManager.types.OPPORTUNITY).clip, channel: YaguarLib.Audio.AudioManager.channels.MUSIC, loop: true);
            video.Play();
        } else {
            YaguarLib.Events.Events.StopChannel(YaguarLib.Audio.AudioManager.channels.MUSIC);
            video.Stop();
        }
    }

    public override void OnClicked() {
        GameManager.Instance.Restart();
        Show(false);
    }
}
