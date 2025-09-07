using UnityEngine;

public class LogotypsManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        Events.OnInitLevel += OnInitLevel;
        Events.OnExitLevel += OnExitLevel;
    }
    void OnDestroy()
    {
        Events.OnInitLevel -= OnInitLevel;
        Events.OnExitLevel -= OnExitLevel;
    }
    void OnInitLevel(int id)
    {
        Debug.Log("#OnInitLevel" + id);
        anim.SetInteger("game",  id+1);
    }
    void OnExitLevel()
    {
        anim.SetInteger("game", 0);
    }
}
