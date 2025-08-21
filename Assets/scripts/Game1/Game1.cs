using System.Collections.Generic;
using UnityEngine;

public class Game1 : Gameplay
{
    public List<int> items;
    int id;
    public List<Slot> slots;
    public List<SimpleButton> buttons;

    public override void InitGame()
    {
        items = new List<int>();
        id = 0;
        int a = 0;
        for (a = 0; a<slots.Count; a++)
        {
            slots[a].Inactive();
            items.Add(a);
        }
        YaguarLib.Xtras.Utils.Shuffle(items);

        a = 0;
        foreach (SimpleButton sb in buttons)
        {
            sb.Init(a, OnClicked);
            a++;
        }
        SetActiveSlot();
    }
    void SetActiveSlot()
    {
        slots[id].SetActive();
    }
    void OnClicked(int buttonID)
    {
        if(items[id] == buttonID)
        {
            buttons[buttonID].GetComponent<Animator>().Play("correct");
            slots[buttonID].SetCorrect(true);
            id++;
            if (id >= slots.Count)
                Done();
            else
                Success();
        }
        else
        {
            buttons[buttonID].GetComponent<Animator>().Play("incorrect");
            slots[buttonID].SetCorrect(false);
        }
    }
    void Done()
    {
        GameManager.Instance.NextGame();
    }
    void Success()
    {
        SetActiveSlot();
    }

}
