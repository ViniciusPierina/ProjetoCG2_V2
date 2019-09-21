using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Destroy(other.gameObject);

        if (other.gameObject.name == "Soldadinho")
            SceneManager.LoadScene("Assets/Scenes/Menu.unity", LoadSceneMode.Single);
    }
}
