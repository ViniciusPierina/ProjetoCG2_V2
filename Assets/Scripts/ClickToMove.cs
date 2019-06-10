using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent mNavMeshAgent;
    public GameObject targetIndicatorPrefab;
    public float maxlength;

    private GameObject targetObject;

    //private bool mRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        //Instantiate click target prefab
        if (targetIndicatorPrefab)
        {
            targetObject = Instantiate(targetIndicatorPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            targetObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            MoveToLocation(Input.mousePosition);
        }

        //if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        //{
        //    mRunning = false;
        //}
        //else
        //{
        //    mRunning = true;
        //}
    }

    void MoveToLocation(Vector2 posOnScreen)
    {
        Ray ray = Camera.main.ScreenPointToRay(posOnScreen);
        RaycastHit hit;

        Debug.Log("Movendo");
        if (Physics.Raycast(ray, out hit, maxlength))
        {
            mNavMeshAgent.destination = hit.point;

            //Show marker where we clicked
            if (targetObject)
            {
                targetObject.transform.position = mNavMeshAgent.destination;
                targetObject.SetActive(true);
            }
        }
    }
}
