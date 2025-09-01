using UnityEngine;
using UnityEngine.Video;

public class PhotoOpportunity : MonoBehaviour
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
        gameObject.SetActive(enable);
        string animName = enable ? "Entry" : "Exit";
        anim.Play(animName, 0, 0);
        if (enable)
            video.Play();
        else
            video.Stop();
    }
}
