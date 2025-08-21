using UnityEngine;

public class SignalUI : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text field;

    public void SetState(string text = "")
    {
        field.text = text;
        gameObject.SetActive(true);
    }
}
