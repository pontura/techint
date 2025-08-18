using UnityEngine;

public class IntroUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text title;
    [SerializeField] TMPro.TMP_Text field;

    public void Init()
    {
        title.text = GameManager.Instance.settings.intro_title;
    }
}
