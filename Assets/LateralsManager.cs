using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LateralsManager : MonoBehaviour
{
    public LateralIlustrations[] gamesIlustrations;
    public GameLaterals[] games;

    [Serializable]
    public class LateralIlustrations
    {
        public Sprite[] sprites;
        public Image[] ilustrationLeft;
        public Image[] ilustrationRight;
        public GameObject[] level_ilustrations;

        public void Reset() {
            foreach (GameObject go in level_ilustrations) go.SetActive(false);
        }
    }

    [Serializable]
    public class GameLaterals
    {
        public GameObject[] games;
        public void Reset() {
            foreach (GameObject go in games) go.SetActive(false);
        }
    }

    void Start()
    {
        Events.OnWinLevel += OnWinLevel;
        Events.OnInitLevel += OnInitLevel;
        Events.OnExitLevel += OnExitLevel;
    }
    void OnDestroy()
    {
        Events.OnWinLevel = OnWinLevel;
        Events.OnInitLevel -= OnInitLevel;
        Events.OnExitLevel -= OnExitLevel;
    }
    private void OnInitLevel(int levelID)
    {
        if (GameManager.Instance.levelId == 2)
            SetLateralTexts();
    }
    private void OnExitLevel()
    {
        
    }
    private void OnWinLevel(int obj)
    {
        Invoke(nameof(SetWinLaterals), 1);
    }

    void SetWinLaterals() {
        LateralIlustrations li = gamesIlustrations[GameManager.Instance.levelId];
        YaguarLib.Xtras.Utils.ShuffleArray<Sprite>(li.sprites);
        for(int i = 0; i < li.ilustrationLeft.Length; i++) {
            li.ilustrationLeft[i].sprite = li.sprites[0];
            li.ilustrationRight[i].sprite = li.sprites[1];
        }

        string[] texts = GameManager.Instance.settings.GetLateralTextWin(GameManager.Instance.levelId);
        YaguarLib.Xtras.Utils.ShuffleArray<string>(texts);
        for (int i = 0; i < li.level_ilustrations.Length; i++) {
            li.level_ilustrations[i].SetActive(true);
            TMPro.TMP_Text field = li.level_ilustrations[i].GetComponentInChildren<TMPro.TMP_Text>();
            field.text = texts[i];
        }
    }

    private void SetLateralTexts()
    {
        Reset();
        GameObject[] gos = games[GameManager.Instance.levelId].games;
        List<TMPro.TMP_Text> fields = new();
        foreach (GameObject go in gos) {
            fields.AddRange(go.GetComponentsInChildren<TMPro.TMP_Text>().ToList());
            //go.SetActive(true); Lo prende LateralManager
        }

        if (fields != null) {
            string[] texts = GameManager.Instance.settings.GetLateralText(GameManager.Instance.levelId);
            YaguarLib.Xtras.Utils.ShuffleArray<string>(texts);
            for (int i = 0; i < fields.Count; i++)
                fields[i].text = texts[i];
        }
    }
    private void Reset()
    {
        foreach (GameLaterals gl in games) gl.Reset();
        foreach (LateralIlustrations li in gamesIlustrations) li.Reset();
    }
}
