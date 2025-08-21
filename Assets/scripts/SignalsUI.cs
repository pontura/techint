using UnityEngine;

public class SignalsUI : MonoBehaviour
{
    [SerializeField] GameObject asset;
    [SerializeField] SignalUI[] signals;
    System.Action OnDone;

    private void Awake()
    {
        print("Awake" + gameObject.name);
        Events.OnSignal += OnSignal;
    }
    private void OnDestroy()
    {
        Events.OnSignal -= OnSignal;
    }
    void OnSignal(string text, int duration, System.Action OnDone)
    {
        this.OnDone = OnDone;
        asset.SetActive(true);

        foreach (SignalUI signal in signals)
            signal.SetState(text);

        Invoke("OnSignalDone", duration);
    }
    void OnSignalDone()
    {
        asset.SetActive(false);
        if (OnDone != null)
            OnDone();
    }
}
