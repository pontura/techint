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
    public void Init(Game2 game, float speed)
    {
        this.speed = speed;
        anim.speed = speed;
        this.game = game;
    }
    public void OnTrivia()
    {
        anim.speed = 0;
        game.OnTrivia();
    }
    public void Play()
    {
        anim.speed = speed;
        game.OnTrivia();
    }
}
