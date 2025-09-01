using extOSC;
using UnityEngine;

public class OSCLogger : MonoBehaviour
{
    public OSCReceiver Receiver;
    public Vector2 pos;
    public Vector2 lastPos;
    [SerializeField] InputManager inputManager;

    void Start()
    {
        if (Receiver == null)
        {
            Debug.LogError("❌ No asignaste el OSCReceiver en el Inspector.");
            return;
        }
        Receiver.LocalHost = GameManager.Instance.settings.ip;
        Debug.Log("✅ OSCLogger inicializado. Escuchando en puerto: " + Receiver.LocalPort);
        Receiver.Bind("/x", SetX);
        Receiver.Bind("/y", SetY);
    }
    void CheckSend()
    {
        if (pos.x == 0 || pos.y == 0)
            return;

        if (lastPos == pos) return;
        lastPos = pos;

        //float _x = (Screen.width/3) * pos.x;
        //_x += Screen.width/3;
        //float _y = Screen.height * pos.y;
        inputManager.OnHit(new Vector2(pos.x, pos.y));

        pos = Vector2.zero; 
    }
    private void SetX(OSCMessage message)
    {
        Debug.Log("📡 OSC recibido en: " + message.Address);
        pos.x = message.Values[0].FloatValue;

        CheckSend();
    }
    private void SetY(OSCMessage message)
    {
        Debug.Log("📡 OSC recibido en: " + message.Address);
        pos.y = message.Values[0].FloatValue;
        CheckSend();
    }
}
