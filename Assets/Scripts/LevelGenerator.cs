using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private int tempo;
    private int duration;
    [SerializeField]
    private Spawner[] spawners;
    [SerializeField]
    private TextAsset file;
    private int ticksElapsed;
    private const int ticksInAMinute = 50 * 60;
    private int ticksInABeat;

    // Start is called before the first frame update
    void Start()
    {
        Data levelData = DataReader.getDataFromJSON(file);
        tempo = levelData.stages[0].tempo;
        //tempo = 60;
        //duration = levelData.stages[0].duration;
        //Debug.Log(tempo);
        //Debug.Log(duration);
        //Debug.Log(levelData.blocks[0].type);
        //Debug.Log(levelData.blocks[0].tempos);
        ticksElapsed = 0;
        ticksInABeat = ticksInAMinute / tempo;
    }

    void FixedUpdate()
    {
        ticksElapsed++;
        if (ticksElapsed >= ticksInABeat)
        {
            Spawn();
            ticksElapsed = 0;
        }
    }

    void Spawn()
    {
        Debug.Log(ticksElapsed);
        foreach (Spawner spawner in spawners)
        {
            spawner.Spawn(SpawnID.PLATFORM);
        }
        
    }
    
}
