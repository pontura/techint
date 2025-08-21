using UnityEngine;

public class Slot : ButtonLidar
{
    public int slotID;
    Animator anim;

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
    }
    public void Inactive()
    {
        anim.Play("inactive");
    }
}
