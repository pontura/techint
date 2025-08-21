using UnityEngine;

public class SimpleButton : ButtonLidar
{
    System.Action<int> OnClickDone;
    int id;

    public void Init(int id, System.Action<int> OnClicked)
    {
        this.id = id;
        this.OnClickDone = OnClicked;
    }
    public override void OnClicked() 
    {
        OnClickDone(id);
    }
}
