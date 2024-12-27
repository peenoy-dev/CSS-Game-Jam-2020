using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DataReader
{
    public static Data getDataFromJSON(TextAsset file)
    {
        Debug.Log(file.text);
        Data data = JsonUtility.FromJson<Data>(file.text);
        
        return data;
    }
}

[System.Serializable]
public class Data
{
    public Stage[] stages;
}

[System.Serializable]
public class Stage
{
    public int tempo;
    public int duration;
    public Segment[] segments;
}

[System.Serializable]
public class Segment
{
    public int[] blocks;
    public int tempos;
}

