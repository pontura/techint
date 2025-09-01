using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager gameManager;
    public Vector2 pos1; 

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Input.mousePosition;
            pos.x /= (float)Screen.width;
            pos.y /= (float)Screen.height;
            OnHit(pos);
        }
#endif
        if (Input.GetKeyDown(KeyCode.Escape))
            gameManager.Esc();
        if (Input.GetKeyDown(KeyCode.F1))
            gameManager.Calibrate();
        if (Input.GetKeyDown(KeyCode.Space))
            gameManager.Space();
    }
    public void OnHit(Vector2 pos)
    {
        this.pos1 = pos;
        gameManager.OnHit(pos);
    }
}
