using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static SettingsData;

public class TriviaUI : MonoBehaviour
{
    [SerializeField] SimpleButton[] buttons;
    [SerializeField] TMPro.TMP_Text fieldTitle;
    [SerializeField] TMPro.TMP_Text field;
    [SerializeField] Animator resultsAnim;
    [SerializeField] Slider slider;

    Game2 game;
    TriviaData d;
    int v;
    float gotoValue;
    public bool done;

    public void Init(Game2 game)
    {
        this.game = game;
        gameObject.SetActive(false);

        buttons[0].Init(0, Add);
        buttons[1].Init(0, Remove);
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
    void Add(int a) { OnClicked(true); }
    void Remove(int a){ OnClicked(false); }

    public void OnClicked(bool add)
    {
        print("OnClicked " + add);        
        if (done) return;

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
                YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.CLICK_GOOD, YaguarLib.Audio.AudioManager.channels.UI);
            }
            else
            {
                YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.CLICK_NEUTRAL, YaguarLib.Audio.AudioManager.channels.UI);
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
        YaguarLib.Events.Events.OnPlaySoundInChannel(YaguarLib.Audio.AudioManager.types.CLICL_BAD, YaguarLib.Audio.AudioManager.channels.UI);
        resultsAnim.Play("MaxLimitReached");
    }
    void Reset()
    {
        gameObject.SetActive(false);
    }
}
