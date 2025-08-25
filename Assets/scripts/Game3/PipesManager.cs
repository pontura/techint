using UnityEngine;
using UnityEngine.UI;

public class PipesManager : MonoBehaviour
{
    [SerializeField] Transform pipesContainer;
    [SerializeField] GridLayoutGroup grid;
    [SerializeField] PipesLevelsManager levelsManager;

    PipesLevelsManager.PipeLevel level;

    Pipe[] pipes;

    System.Action OnDone;


    private void Start() {
        Events.OnPipeRotate += CheckDone;
    }

    private void OnDestroy() {
        Events.OnPipeRotate -= CheckDone;
    }

    public void Init(System.Action onDone) {
        level = levelsManager.GetCurrentLevel();
        pipes = pipesContainer.GetComponentsInChildren<Pipe>();
        for (int i = 0; i < pipes.Length; i++) {
            pipes[i].SetRotation(level.pipeInitialRotations[i / grid.constraintCount][i % grid.constraintCount]);
            pipes[i].SetTileId(level.pipeStates[i / grid.constraintCount][i % grid.constraintCount]);
        }

        OnDone = onDone;
    }


#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T)) {
            ExportData(true);
        }else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R)) {
            ExportData(false);
        }
    }
#endif

    void CheckDone() {
        //Debug.Log("CheckDone");
        for (int i = 0; i < pipes.Length; i++) {
            //Debug.Log((i / grid.constraintCount) + "," + (i % grid.constraintCount));
            if (level.pipeRotationsDone[i / grid.constraintCount][i % grid.constraintCount] > -1 && level.pipeStates[i / grid.constraintCount][i % grid.constraintCount]>0) {                
                if (level.pipeStates[i / grid.constraintCount][i % grid.constraintCount] == 2) {
                    if (pipes[i].RotationState != level.pipeRotationsDone[i / grid.constraintCount][i % grid.constraintCount]) {
                        //Debug.Log((i / grid.constraintCount)+","+ (i % grid.constraintCount)+": "+level.pipeRotationsDone[i / grid.constraintCount][i % grid.constraintCount] + " == " + pipes[i].RotationState);
                        return;
                    }                        
                } else {
                    if (pipes[i].RotationState % 2 != level.pipeRotationsDone[i / grid.constraintCount][i % grid.constraintCount] % 2) {
                        //Debug.Log((i / grid.constraintCount) + "," + (i % grid.constraintCount) + ": " + level.pipeRotationsDone[i / grid.constraintCount][i % grid.constraintCount] + " == " + pipes[i].RotationState);
                        return;
                    }
                }
            }
        }
        Debug.Log("Complete!");
        OnDone();
    }

    void ExportData(bool tiles) {
        string json = "\"pipeStates\":[";
        Pipe[] pipes = pipesContainer.GetComponentsInChildren<Pipe>();
        for(int i = 0; i < pipes.Length; i++) { 
            if (i % grid.constraintCount == 0)
                json += "\"";
            Debug.Log(pipes[i].gameObject.name);
            if(tiles)
                json += "" + pipes[i].TileId;
            else
                json += "" + pipes[i].RotationState;
            if (i % grid.constraintCount == grid.constraintCount - 1) {
                json += "\"";
                if(i<pipes.Length-1)
                    json += ",";
            } else
                json += ",";
        }
        json += "]";
        Debug.Log(json);
    }

}
