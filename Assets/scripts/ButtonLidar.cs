using UnityEngine;

public class ButtonLidar : MonoBehaviour
{
    public void OnButtonLidarClick()
    {
        Debug.Log("Lidar button Clicked: " + gameObject.name);
        OnClicked();
    }
    public virtual void OnClicked() { }
}
