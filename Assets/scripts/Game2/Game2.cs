using System.Collections;
using System.Linq;
using UnityEngine;
using static SettingsData;

public class Game2 : Gameplay
{
    int triviaID;
    float triviaSpeed;
    [SerializeField] TriviaLine line;
    [SerializeField] TriviaUI ui;

    private void Start()
    {
        ui.Init(this);
        line.Init(this);
    }
    public override void InitGame()
    {
        print("InitGame 2");
        ui.SetOff();
        triviaSpeed = GameManager.Instance.settings.triviaSpeed;
        triviaID = 0;
        line.SetSpeed(triviaSpeed);
        line.Reset();
        //OnTrivia();
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
        GameManager.Instance.Win(playerID);
    }

}
