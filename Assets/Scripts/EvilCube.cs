using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilCube : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(other.gameObject);
    //}
}
