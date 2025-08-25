using UnityEngine;
using static SettingsData;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text fieldTitle;
    [SerializeField] TMPro.TMP_Text field;
    Game2 game;
    TriviaData d;
    int v;

    public void Init(Game2 game)
    {
        this.game = game;
        gameObject.SetActive(false);
    }

    public void OnActive(TriviaData d)
    {
        gameObject.SetActive(true);
        this.d = d;
        fieldTitle.text = d.trivia;
        if (Random.Range(0, 10) > 5)
            v = d.trivia_valor_inicial_1;
        else
            v = d.trivia_valor_inicial_2;
        field.text = v.ToString();
    }
    public void OnClicked(bool add)
    {
        print("OnClicked " + add);
        if (add) 
            v += d.trivia_valor_add;
        else 
            v -= d.trivia_valor_add;

        field.text = v.ToString();

        if (v == d.trivia_valor)
        {
            game.OnTriviaAnswer(true);
            gameObject.SetActive(false);
        }
        else
        {
            game.OnTriviaAnswer(false);
        }
    }
}
