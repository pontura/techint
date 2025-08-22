using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Gameplay[] game1;
    public Gameplay[] game2;
    public Gameplay[] game3;

    public Transform[] containers;
    Gameplay[] games;

    public void Init(int id)
    {
        foreach (Gameplay g in game1) g.SetOn(false);
        foreach (Gameplay g in game2) g.SetOn(false);
        foreach (Gameplay g in game3) g.SetOn(false);

        // show 
        if (id == 0) games = game1;
        else if (id == 1) games = game2;
        else if (id == 2) games = game3;

        foreach (Gameplay g in games)
            g.SetOn(true);
    }
    public void InitGame()
    {
        foreach (Gameplay g in games)
            g.InitGame();
    }
}
