using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class PipesLevelsManager : MonoBehaviour
{
    [SerializeField] string filename = "pipeLevel.json";
    [SerializeField] PipeLevels levels;
    [field: SerializeField] public PipeLevel CurrentLevel { get; private set; }

    [Serializable]
    public class PipeLevels
    {
        public PipeLevel[] pipeLevels;
    }


    [Serializable]
    public class PipeLevel
    {
        public int[][] pipeStates;
        public int[][] pipeInitialRotations;
        public int[][] pipeRotationsDone;
        public string[] pipeStatesData;
        public string[] pipeInitialRotationsData;
        public string[] pipeRotationsDoneData;

        public void ParseStateData() {
            pipeStates = new int[pipeStatesData.Length][];
            for(int i = 0; i < pipeStatesData.Length; i++) {
                pipeStates[i] = pipeStatesData[i].Split(',').Select(int.Parse).ToArray();
            }
        }

        public void ParseInitialRotation() {
            pipeInitialRotations = new int[pipeInitialRotationsData.Length][];
            for (int i = 0; i < pipeInitialRotationsData.Length; i++) {
                pipeInitialRotations[i] = pipeInitialRotationsData[i].Split(',').Select(int.Parse).ToArray();
            }
        }

        public void ParseRotationDone() {
            pipeRotationsDone = new int[pipeRotationsDoneData.Length][];
            for (int i = 0; i < pipeRotationsDoneData.Length; i++) {
                pipeRotationsDone[i] = pipeRotationsDoneData[i].Split(',').Select(int.Parse).ToArray();
            }
        }
    }

    private void Start() {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath + "/", filename);
        UnityEngine.Debug.Log(filePath);
        if (System.IO.File.Exists(filePath)) {
            string dataAsJson = System.IO.File.ReadAllText(filePath);
            UnityEngine.Debug.Log(dataAsJson);
            levels = JsonUtility.FromJson<PipeLevels>(dataAsJson);
            CurrentLevel = levels.pipeLevels[0];
            Debug.Log(levels == null);
            
            CurrentLevel.ParseStateData();
            CurrentLevel.ParseInitialRotation();
            CurrentLevel.ParseRotationDone();

        }
    }    
}
