using UnityEngine;
using UnityEngine.Video;

public class PhotoOpportunity : ButtonLidar
{
    [SerializeField] VideoPlayer video;
    [SerializeField] Animator anim;

    bool _lock;

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
        gameObject.SetActive(enable);
        YaguarLib.Audio.AudioManager.Instance.SfxEnable(!enable);
        string animName = enable ? "Entry" : "Exit";
        anim.Play(animName, 0, 0);
        if (enable) {
            YaguarLib.Audio.AudioManager.Instance.PlaySound(YaguarLib.Audio.AudioManager.Instance.GetAudio(YaguarLib.Audio.AudioManager.types.OPPORTUNITY).clip, channel: YaguarLib.Audio.AudioManager.channels.MUSIC, loop: true);            
            video.Play();
            Events.OnClickTimerSet((state) => _lock = state);
        } else {
            YaguarLib.Events.Events.StopChannel(YaguarLib.Audio.AudioManager.channels.MUSIC);
            video.Stop();
        }
    }

    public override void OnClicked() {
        if (_lock)
            return;
        GameManager.Instance.Restart();
        Show(false);
    }
}
