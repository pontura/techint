using UnityEngine;

public class IntroUI : ButtonLidar
{
    [SerializeField] TMPro.TMP_Text title;
    [SerializeField] TMPro.TMP_Text field;

    public override void OnClicked()
    {
        print("OnClicked");
        GameManager.Instance.InitGame();
    }
    public void Init()
    {
        title.text = GameManager.Instance.settings.intro_title;
    }
}
