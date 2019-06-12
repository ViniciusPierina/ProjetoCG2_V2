using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoldierCollider : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DGSK")
        {
            SceneManager.LoadScene("Assets\\Scenes\\Menu.unity", LoadSceneMode.Single);
        }
    }
}
