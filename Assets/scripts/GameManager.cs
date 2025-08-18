using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using YaguarLib.Audio;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Text field;
    InputManager inputManager;
    public states state;

    public enum states
    {
        intro,
        game1,
        game2,
        game3,
        calibrate,
        summary,
        game_paused
    }
    [Serializable]
    public class SettingsData
    {
        public int totalTime;
        public string intro_title;
        public string level_1_title;
        public string level_2_title;
        public string level_3_title;
    }

    static GameManager mInstance = null;
    [SerializeField] UIManager uiManager;
    public QuadUtils quadUtils;
    public SettingsData settings;

    public static GameManager Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        if (!mInstance)
            mInstance = this;
        Events.CalibrationDone += CalibrationDone;
        Events.TimeOver += TimeOver;
        Events.LevelComplete += LevelComplete;
    }

    private void LevelComplete()
    {
        StopAllCoroutines();
        state = states.game_paused;
    }
    void OnInitLevel()
    {
        state = states.game1;
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

        posNormalized.x *= Screen.width;
        posNormalized.y *= Screen.height;
        return posNormalized;

    }
    public void OnHit(Vector2 _pos)
    {
        //-1 to 1:
        Vector2 pos = NormalizedToScreenPos(_pos);

        //if (state == states.game)
        //    enemiesManager.CheckHit(pos);
        //else 
        if(state == states.calibrate)
            uiManager.DebugPoint(pos);
    }
    public void Space()
    {
        if (state == states.intro)
            InitGame();
        else if (state == states.calibrate)
            uiManager.CalibrateClicked(inputManager.pos1);
        else if (state == states.summary)
            Intro();
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
        field.gameObject.SetActive(false);
        Cursor.visible = false;
        state = states.game_paused;
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
        else if (state == states.game1 || state == states.game2 || state == states.game3)
            EndGame();
        else if (state == states.summary)
            Intro();
    }
    private void TimeOver()
    {
        Summary();
    }
    void EndGame()
    {
        Intro();
    }

}
