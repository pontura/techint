using UnityEngine;
//using extOSC;
using System.Collections.Generic;
using System;

public class OSCExampleReceiver : MonoBehaviour
{
    //InputManager inputManager;
    //[SerializeField] TMPro.TMP_Text field;
    //public OSCReceiver receiver;

    //float filterDuration = 0.25f;
    //int offset = 10;
    //string key = "objeto";   

    //public List<ObjectData> data;

    //[Serializable]
    //public class ObjectData
    //{
    //    public Vector2 pos;
    //    public Vector2 last_pos;
    //    public float last_pos_timer;
    //}

    //private void Update()
    //{
    //    if(Input.GetMouseButton(0))
    //    {
    //        data[0].pos.x = Input.mousePosition.x;
    //        data[0].pos.y = Input.mousePosition.y;
    //        CheckPos(data[0]);
    //    }
    //}

    //public void Start()
    //{  
    //    for (int i = 0; i < 3; i++)
    //        data.Add (new ObjectData ());

    //    inputManager = GetComponent<InputManager>();
    //    print("OSCExampleReceiver");

    //    for (int i = 0; i < 3; i++)
    //    {
    //        int index = i;
    //        receiver.Bind("/" + key + (index + 1) + "x", message => OnPosX(data[index], message));
    //        receiver.Bind("/" + key + (index + 1) + "y", message => OnPosY(data[index], message));
    //    }
    //}

    //void OnPosX(ObjectData d,  OSCMessage message)
    //{
    //    d.pos.x = (int)message.Values[0].IntValue;
    //    CheckPos(d);
    //}
    //void OnPosY(ObjectData d, OSCMessage message)
    //{
    //    d.pos.y = (int)message.Values[0].IntValue;
    //    CheckPos(d);
    //}
    //public void CheckPos(ObjectData d)
    //{
    //    if (d.pos.x == 0 || d.pos.y == 0) return;
    //    if (d.last_pos_timer + filterDuration > Time.time) return;
    //        d.last_pos = d.pos;
    //        d.last_pos_timer = Time.time;
    //        inputManager.OnHit(d.pos);
    //        field.text = d.pos.ToString();
    //        d.pos = Vector2.zero;
    //}
}
