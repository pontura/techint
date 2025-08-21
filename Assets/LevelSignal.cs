using UnityEngine;

public class LevelSignal : MonoBehaviour
{
    public states state;
    public enum states
    {
        idle,
        current,
        win,
        lose
    }
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void SetState(states state)
    {
        anim.Play(state.ToString());
    }
}
