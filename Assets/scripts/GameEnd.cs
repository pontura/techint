
using UnityEngine;

public class GameEnd : Gameplay
{
    public TMPro.TMP_Text[] titles;

    public override void InitGame()
    {
        int winner = GameManager.Instance.GetWinner();

        if (winner == playerID)
            GetComponent<Animator>().Play("win");
        else
            GetComponent<Animator>().Play("lose");

        foreach (TMPro.TMP_Text t in titles)
        {
            if (winner == playerID)
                t.text = GameManager.Instance.settings.gameEnd_win;
            else if (winner == 0)
                t.text = GameManager.Instance.settings.gameEnd_draw;
            else
                t.text = GameManager.Instance.settings.gameEnd_lose;
        }
        Invoke("Done", GameManager.Instance.settings.timeForSummary);
    }
   
    void Done()
    {
        GameManager.Instance.Restart();
    }

}
