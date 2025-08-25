using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static SettingsData;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text fieldTitle;
    [SerializeField] TMPro.TMP_Text field;
    [SerializeField] Animator resultsAnim;
    [SerializeField] Slider slider;

    Game2 game;
    TriviaData d;
    int v;
    float gotoValue;
    bool done;

    public void Init(Game2 game)
    {
        this.game = game;
        gameObject.SetActive(false); 
    }
    public void SetInitialValue()
    {
        done = false;
        v = d.trivia_valor_inicial;
        CalculateSlider();
        slider.value = gotoValue;
        field.text = v.ToString();
    }
    private void Update()
    {
        if (this.d == null) return;
        slider.value = Mathf.Lerp(slider.value, gotoValue, 0.1f);
    }
    public void OnActive(TriviaData d)
    {
        gameObject.SetActive(true);
        this.d = d;
        fieldTitle.text = d.trivia;        
        field.text = v.ToString();
        SetInitialValue();
    }
    public void OnClicked(bool add)
    {
        if (done) return;
        print("OnClicked " + add);

        if (d.trivia_valor_inicial > d.trivia_valor && add)
            MaxLimitReached();
        else if (d.trivia_valor_inicial < d.trivia_valor && !add)
            MaxLimitReached();
        else
        {
            if (add)
                v += d.trivia_valor_add;
            else
                v -= d.trivia_valor_add;

            field.text = v.ToString();
            CalculateSlider();

            if (v == d.trivia_valor)
            {
                done = true;
                resultsAnim.Play("triviaOut");
                Invoke("Reset", 0.25f);
                game.OnTriviaAnswer(true);
            }
            else
            {
                game.OnTriviaAnswer(false);
            }
        }
    }
    void CalculateSlider()
    {
        float f = ((float)v - (float)d.trivia_valor) / ((float)d.trivia_valor_inicial - (float)d.trivia_valor);

        gotoValue = (0.5f + (f / 2));

        if (d.trivia_valor_inicial < d.trivia_valor) gotoValue = 1 - gotoValue;
        print("gotoValue " + gotoValue);
    }
    void MaxLimitReached()
    {
        resultsAnim.Play("MaxLimitReached");
    }
    void Reset()
    {
        gameObject.SetActive(false);
    }
}
