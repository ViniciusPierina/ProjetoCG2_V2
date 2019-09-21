using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SoldierCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetBool("running", false); ;


        //if (collision.gameObject.name == "DGSK")
        //{
        //    SceneManager.LoadScene("Assets\\Scenes\\Menu.unity", LoadSceneMode.Single);
        //}
    }
}
