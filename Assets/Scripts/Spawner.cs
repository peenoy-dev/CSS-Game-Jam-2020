using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject platform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(SpawnID id)
    {
        switch (id)
        {
            case SpawnID.PLATFORM:
                Instantiate(platform, this.transform.position, new Quaternion(0, 0, 0, 0));
                break;
            default:
                break;
        }
        
    }
}
