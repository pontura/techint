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
    public void SetState(states state)
    {
        if(anim==null)
            anim = GetComponent<Animator>();
        anim.Play(state.ToString());
    }
}
