using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class Pipe : ButtonLidar
{
    [SerializeField] List<Animator> tiles;
    [field: SerializeField] public int TileId { get; private set; }
    [field: SerializeField] public int RotationState { get; private set; }

    public override void OnClicked() {

        Debug.Log("pipeClicked");
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
            TileId++;
            TileId = TileId % 5;
            SetTile();
        } else {
            RotationState++;
            RotationState = RotationState % 4;
            Rotate();
            Events.OnPipeRotate();
        }
#else
        RotationState++;
        RotationState = RotationState % 4;
        Rotate();
        if(OnRotate!=null)
                OnRotate();
#endif
    }

    public void SetRotation(int rotation) {
        RotationState = rotation;
        Rotate();
    }
    void Rotate() {
        transform.rotation = Quaternion.Euler(0, 0, RotationState * 90);
    }

    public void SetTileId(int tile) {
        TileId = tile;
        SetTile();
    }

    void SetTile() {
        for (int i = 0; i < tiles.Count; i++)
            tiles[i].gameObject.SetActive(i == TileId);
    }

    public void SetWin() {
        tiles[TileId].Play("on",0,0);
    }

    public void SetOff() {
        tiles[TileId].Play("off", 0, 0);
    }
}
