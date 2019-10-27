using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{
    public  GameObject CylinderCoke;
    public Vector3 size;
    public Vector3 center;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating ("SpawnTrash", spawnTime, spawnDelay) ;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
    void onDraw(){
        Gizmos.DrawCube(center, size);
    }

    public void SpawnTrash(){
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),Random.Range(-size.y / 2, size.y / 2),Random.Range(-size.z / 2, size.z / 2));
        Instantiate(CylinderCoke,pos,Quaternion.identity); 
        if(stopSpawning){
            CancelInvoke("SpawnTrash");
        }
    }
}
