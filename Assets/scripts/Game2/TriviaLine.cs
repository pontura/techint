using UnityEngine;

public class TriviaLine : MonoBehaviour
{
    Animator anim;
    float speed;
    Game2 game;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }
    public void Init(Game2 game)
    {
        this.game = game;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void OnTrivia()
    {
        print("OnTrivia");
        anim.speed = 0;
        game.OnTrivia();
    }
    public void Play()
    {
        anim.speed = speed;
    }
}
