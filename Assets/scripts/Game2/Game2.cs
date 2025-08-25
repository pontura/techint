using System.Collections;
using System.Linq;
using UnityEngine;
using static SettingsData;

public class Game2 : Gameplay
{
    int id;
    Animator anim;
    int triviaID;
    float triviaSpeed;
    [SerializeField] TriviaLine line;
    [SerializeField] TriviaUI ui;

    public override void InitGame()
    {
        triviaSpeed = GameManager.Instance.settings.triviaSpeed;
        anim = GetComponent<Animator>(); 
        triviaID = 0;
        line.Init(this, triviaSpeed);
        ui.Init(this);
    }       
    public void OnTrivia()
    {
        if (triviaID >= GameManager.Instance.settings.trivias.Length)
            Done();
        else
        {
            TriviaData td = GameManager.Instance.settings.trivias[triviaID];
            ui.OnActive(td);
        }
    }
    public void OnTriviaAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            line.Play();
            triviaID++;
        }
    }
    void Done()
    {
        GameManager.Instance.NextGame();
    }

}
