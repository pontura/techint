
using UnityEngine;

public class GameEnd : Gameplay
{
    public TMPro.TMP_Text[] titles;

    public override void InitGame()
    {
        int winner = GameManager.Instance.GetWinner();
        foreach (TMPro.TMP_Text t in titles)
        {
            if (winner == playerID)
            {

                t.text = GameManager.Instance.settings.gameEnd_win;
                GetComponent<Animator>().Play("win");
            }
            else
            {
                t.text = GameManager.Instance.settings.gameEnd_lose;
                GetComponent<Animator>().Play("lose");
            }
        }
        Invoke("Done", GameManager.Instance.settings.timeForSummary);
    }
   
    void Done()
    {
        GameManager.Instance.Restart();
    }

}
