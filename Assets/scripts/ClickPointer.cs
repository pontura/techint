using UnityEngine;

public class ClickPointer : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Done", 0.3f);
    }
    public void Init(Vector2 pos)
    {
        gameObject.SetActive(true);
        transform.position = pos;
    }
    void Done()
    {
        gameObject.SetActive(false);
    }
}
