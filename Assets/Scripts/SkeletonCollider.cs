using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
