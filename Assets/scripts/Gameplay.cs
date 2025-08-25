using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public int playerID = 1;
    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }    
    public virtual void InitGame()
    {
        Debug.Log("init");
    }
}
