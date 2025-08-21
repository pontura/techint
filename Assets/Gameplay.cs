using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }    
    public void InitGame()
    {
        Debug.Log("init");
    }
}
