using UnityEngine;

public class PipesGame : Gameplay
{
    [SerializeField] PipesManager pipesManager;
    bool done;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void InitGame() {
        done = false;
        pipesManager.Init(Done);
    }

    void Done()
    {
        print("Done" + done);
        if (done) return;
        done = true;
        GameManager.Instance.NextGame();
    }
}
