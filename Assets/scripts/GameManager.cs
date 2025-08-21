using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;
using YaguarLib.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameUI ui;
    [SerializeField] TMPro.TMP_Text field;
    InputManager inputManager;
    public states state;
    public int levelId = 0;
    public enum states
    {
        intro,
        game,
        calibrate,
        summary,
        game_paused
    }

    static GameManager mInstance = null;
    [SerializeField] UIManager uiManager;
    public QuadUtils quadUtils;
    public SettingsData settings;
    public GameObject debugClick;

    public static GameManager Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        settings = new SettingsData();
        inputManager = GetComponent<InputManager>();
        if (!mInstance)
            mInstance = this;
        Events.CalibrationDone += CalibrationDone;
        Events.TimeOver += TimeOver;
        Events.LevelComplete += LevelComplete;
    }

    private void LevelComplete(int winner)
    {
        StopAllCoroutines();
        state = states.game_paused;
    }
    private void OnDestroy()
    {
        Events.CalibrationDone -= CalibrationDone;
        Events.TimeOver -= TimeOver;
        Events.LevelComplete -= LevelComplete;
    }
    void Start()
    {
        LoadSettings();
        Init();
    }
    void Init()
    {
        uiManager.Init();
        Intro();
    }
    void LoadSettings()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "settings.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            settings = JsonUtility.FromJson<SettingsData>(json);

            Debug.Log("Settings loaded: " + json);
        }
        else
        {
            Debug.LogWarning("Settings file not found at " + path);
        }
    }
    private void Update()
    {
        uiManager.OnUpdate();
    }
    Vector2 NormalizedToScreenPos(Vector2 pos)
    {
        Vector2 posNormalized = GameManager.Instance.quadUtils.FindUVInQuad(pos);

        posNormalized.x += 1;
        posNormalized.y += 1;

        posNormalized.x /= 2;
        posNormalized.y /= 2;

        posNormalized.x *= (Screen.width/3);
        posNormalized.y *= Screen.height;

        posNormalized.x += Screen.width / 3;
        return posNormalized;

    }
    public void OnHit(Vector2 _pos)
    {
        //-1 to 1:
        Vector2 pos = NormalizedToScreenPos(_pos);
        debugClick.transform.position = pos;
        CheckHitOnUI(pos);
        //if (state == states.game)
        //    enemiesManager.CheckHit(pos);
        //else 
        if (state == states.calibrate)
            uiManager.DebugPoint(pos);
    }
    void CheckHitOnUI(Vector2 pos)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = pos;

        // Raycast contra la UI
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            ButtonLidar button = result.gameObject.GetComponent<ButtonLidar>();
            if (button != null)
            {
                // Emulamos el click
                button.OnButtonLidarClick();
            }
        }
    }
    public void Space()
    {
        //if (state == states.intro)
        //    InitGame();
        //else 
        if (state == states.calibrate)
            uiManager.CalibrateClicked(inputManager.pos1);
        //else if (state == states.summary)
        //    Intro();
    }
    public void Intro()
    {
        field.gameObject.SetActive(false);
        Cursor.visible = true;
        state = states.intro;
        uiManager.SetScreen(state);
    }
    public void InitGame()
    {
        levelId = 0;
        ui.Restart();
        field.gameObject.SetActive(false);
#if !UNITY_EDITOR
        Cursor.visible = false;
#endif
        state = states.game_paused;
        uiManager.SetScreen(state);
    }
    public void GameTutorialDone()
    {
        state = states.game;
    }
    public void NextGame()
    {
        levelId ++;
        ui.SetGamePlay(levelId);

    }
    void OnNext()
    {
    }
    public void Calibrate()
    {
        field.gameObject.SetActive(true);
        state = states.calibrate;
        uiManager.SetScreen(state);
    }
    public void Summary()
    {
        state = states.summary;
        uiManager.SetScreen(state);
    }
    void CalibrationDone()
    {
        print("CalibrationDone");
        Intro();
    }
    public void Esc()
    {
        if (state == states.calibrate)
            CalibrationDone();
        else if (state == states.game)
            EndGame();
        else if (state == states.summary)
            Intro();
    }
    private void TimeOver()
    {
        string text = settings.timeOver;
        int duration = settings.timeOverDuration;
        Events.OnSignal(text, duration, NextGame);
        Summary();
    }
    void EndGame()
    {
        Intro();
    }

}
