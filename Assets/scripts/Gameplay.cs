using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }    
    public virtual void InitGame()
    {
        Debug.Log("init");
    }
}
