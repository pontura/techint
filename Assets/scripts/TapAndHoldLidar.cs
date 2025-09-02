using UnityEngine;

public class TapAndHoldLidar : ButtonLidar
{
    [SerializeField] Animation anim;
    [SerializeField] float timeThresh;
    private bool isHolding;
    public override void OnClicked() {
        CancelInvoke();
        if (!isHolding) {
            isHolding = true;
            Invoke(nameof(StopHold), timeThresh);
            anim.Play();
        } else {
            Debug.Log("#ACA");
            Events.PhotoOpportunityShow(true);
            StopHold();
        }
    }

    void StopHold() {
        isHolding = false;
        anim.Stop();
    }
}
