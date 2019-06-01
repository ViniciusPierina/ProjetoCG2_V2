using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefab;
    public float repeatTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);
    }


    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
