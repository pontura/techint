using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] IntroUI intro;
    [SerializeField] GameUI game;
    [SerializeField] CalibrateUI calibrate;

    public void Init()
    {
        game.Init();
        intro.Init();
        calibrate.Init();
    }
    public void OnUpdate()
    {
        switch (GameManager.Instance.state)
        {
            case GameManager.states.intro:
                break;
            case GameManager.states.calibrate:
                break;
            case GameManager.states.summary:
                break;
            case GameManager.states.game:
                game.OnUpdate();
                break;
            default:
                break;
        }
    }
    public void SetScreen(GameManager.states state)
    {
        switch (state)
        {
            case GameManager.states.intro:
                intro.gameObject.SetActive(true);
                game.gameObject.SetActive(false);
                calibrate.gameObject.SetActive(false);
                break;
            case GameManager.states.game:
            case GameManager.states.game_paused:
                intro.gameObject.SetActive(false);
                game.gameObject.SetActive(true);
                calibrate.gameObject.SetActive(false);
                break;
            case GameManager.states.calibrate:
                intro.gameObject.SetActive(false);
                game.gameObject.SetActive(false);
                calibrate.gameObject.SetActive(true);
                calibrate.InitCalibrate();
                break;
            case GameManager.states.summary:
                intro.gameObject.SetActive(false);
                game.gameObject.SetActive(false);
                calibrate.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void CalibrateClicked(Vector2 pos)
    {
        calibrate.Set(pos);
        calibrate.Next();
    }
    public void DebugPoint(Vector2 pos)
    {
        print("Pos_ " + pos);
    }
}
