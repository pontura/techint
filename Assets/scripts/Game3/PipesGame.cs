using UnityEngine;

public class PipesGame : Gameplay
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void InitGame() {
    }

    void Done() {
        GameManager.Instance.NextGame();
    }
}
