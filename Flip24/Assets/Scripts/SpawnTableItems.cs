using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTableItems : MonoBehaviour
{
    public List<GameObject> tableItems = new List<GameObject>();
    Vector3 spawnPos1; 
    Vector3 spawnPos2;
    int itemToSpawn1;
    int itemToSpawn2;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos1 = transform.position + new Vector3(0.8f, 2f);
        spawnPos2 = transform.position + new Vector3(-0.5f, 2f); 
        itemToSpawn1 = Random.Range(0, 8);   
        itemToSpawn2 = Random.Range(0, 8);
        Instantiate(tableItems[itemToSpawn1] , spawnPos1, Quaternion.identity);
        Instantiate(tableItems[itemToSpawn2] , spawnPos2, Quaternion.identity);
    }
  
}
