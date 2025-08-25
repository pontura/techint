using UnityEngine;

public class SimpleButton : ButtonLidar
{
    System.Action<int> OnClickDone;
    int id;
    public bool done;
    public void Init(int id, System.Action<int> OnClicked)
    {
        done = false;
        this.id = id;
        this.OnClickDone = OnClicked;
    }
    public override void OnClicked() 
    {
        if (done) return;
        if(OnClickDone != null)
            OnClickDone(id);
    }
    public void Done()
    { 
        done = true; 
    }
}
