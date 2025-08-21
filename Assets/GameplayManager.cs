using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Gameplay game1;
    public Gameplay game2;
    public Gameplay game3;
    public Transform[] containers;
    public List<Gameplay> all;

    public void Init(int id)
    {
        all.Clear();
        Gameplay g = game1;
        foreach (Transform t in containers)
        {
            YaguarLib.Xtras.Utils.RemoveAllChildsIn(t);
            Gameplay newGamePlay = Instantiate(g, t);
            newGamePlay.transform.localPosition = Vector3.zero;
            newGamePlay.SetOn(true);
            all.Add(newGamePlay);
        }
    }
    public void InitGame()
    {
        foreach (Gameplay g in all)
            g.InitGame();
    }
}
