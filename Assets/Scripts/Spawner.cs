using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int numberOfCheckPoints;
    public CheckPoint[] checkPoints;
    public CheckPoint lastCheckPoint;
    public GameObject firstSpawn;
    public GameObject obj;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnEntity();
    }

    // Update is called once per frame
    void Update()
    {
        checkSpawnPoint();
    }

    public void spawnEntity(){
        player = Instantiate(obj, firstSpawn.transform.position, firstSpawn.transform.rotation);
        Debug.Log("Spawn");
    }

    public void spawnEntityAtCheckPoint(){
        player = Instantiate(obj, lastCheckPoint.transform.position, lastCheckPoint.transform.rotation);
        Debug.Log("Checkpoint Spawn");
    }

    public void checkSpawnPoint(){
        if(player == null && lastCheckPoint != null){
            spawnEntityAtCheckPoint();
        }
        else if(player == null && lastCheckPoint == null) {
            spawnEntity();
        }
    }

}
