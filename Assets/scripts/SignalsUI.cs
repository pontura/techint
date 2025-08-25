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
        Events.OnSignalByPlayer += OnSignalByPlayer;
    }
    private void OnDestroy()
    {
        Events.OnSignal -= OnSignal;
        Events.OnSignalByPlayer -= OnSignalByPlayer;
    }
    void OnSignal(string text, int duration, System.Action OnDone)
    {
        this.OnDone = OnDone;
        asset.SetActive(true);

        foreach (SignalUI signal in signals)
            signal.SetState(text);

        Invoke("OnSignalDone", duration);
    }
    void OnSignalByPlayer(string text, int player, int duration, System.Action OnDone)
    {
        this.OnDone = OnDone;
        asset.SetActive(true);

        signals[player-1].SetState(text);

        Invoke("OnSignalDone", duration);
    }
    void OnSignalDone()
    {
        asset.SetActive(false);
        if (OnDone != null)
            OnDone();
    }
}
