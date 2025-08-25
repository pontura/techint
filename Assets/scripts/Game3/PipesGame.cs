using UnityEngine;

public class PipesGame : Gameplay
{
    [SerializeField] PipesManager pipesManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void InitGame() {
        pipesManager.Init(Done);
    }

    void Done() {
        GameManager.Instance.NextGame();
    }
}
