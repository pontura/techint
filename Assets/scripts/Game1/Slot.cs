using UnityEngine;

public class Slot : ButtonLidar
{
    public int slotID;
    Animator anim;
    [SerializeField] TMPro.TMP_Text field;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public override void OnClicked()
    {
        Debug.Log("Slot clicked: " + slotID);
    }
    public void SetCorrect(bool isCorrect)
    {
        if (isCorrect)
            anim.Play("correct");
        else
            anim.Play("incorrect");
    }
    public void SetActive()
    {
        anim.Play("active");
        if (field != null)
        {
            string text = GameManager.Instance.settings.GetSlotText(slotID);
            field.text = text;
        }
    }
    public void Inactive()
    {
        anim.Play("inactive");
    }
}
