using UnityEngine;

public class PipesGame : Gameplay
{
    [SerializeField] PipesManager pipesManager;
    bool done;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void InitGame() {
        done = false;
        pipesManager.Init(Win);
    }

    void Win()
    {
        print("Done" + done);
        if (done) return;
        done = true;
        GameManager.Instance.Win(playerID);
    }
}
