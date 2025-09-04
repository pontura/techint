using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager gameManager;
    public Vector2 pos1;
    public float offset_x = 0.26f;
    public float offset_multiplier = 2.6f;

    float p1_timer_click;
    float p2_timer_click;

    float lastClickTime;

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

            pos.x = (pos.x - offset_x) * offset_multiplier;

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
        lastClickTime = Time.realtimeSinceStartup;
        CancelInvoke();
        Invoke(nameof(IsInactive), GameManager.Instance.settings.inactive_thresh);
        if (pos.x<0.5f)
        {
            if (p1_timer_click != 0 && (p1_timer_click + GameManager.Instance.settings.click_delay_filter > Time.time)) 
            {
                print("SKIP CLICK");
                return; 
            } 
            p1_timer_click = Time.time;
        }
        else
        {
            if (p2_timer_click != 0 && (p2_timer_click + GameManager.Instance.settings.click_delay_filter > Time.time))
            {
                print("SKIP CLICK");
                return; 
            }
            p2_timer_click = Time.time;
        }
        this.pos1 = pos;
        gameManager.OnHit(pos);
    }

    void IsInactive() {
        GameManager.Instance.GameIsInactive();
    }
}
