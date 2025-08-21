using UnityEngine;

public class Slot : ButtonLidar
{
    public int slotID;

    public override void OnClicked()
    {
        Debug.Log("Slot clicked: " + slotID);
    }
}
