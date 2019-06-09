using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class RTSPlayerController : MonoBehaviour
{

	public Camera playerCamera;
	public Vector3 cameraOffset;
	public GameObject targetIndicatorPrefab;
	NavMeshAgent agent;
	GameObject targetObject;

    public GameObject arrow; 
    public Transform shotSpawn;
    public float fireRate;
    public float speed = 100f;

    private float nextFire;

    // Use this for initialization
    void Start()
	{
		agent = GetComponent<NavMeshAgent>();
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
#if (UNITY_ANDROID || UNITY_IOS || UNITY_WP8 || UNITY_WP8_1) && !UNITY_EDITOR
            //Handle mobile touch input
            for (var i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    MoveToTarget(touch.position);
                }
            }
#else
		//Handle mouse input
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			MoveToTarget(Input.mousePosition);
		}

        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shoot =  Instantiate(arrow, shotSpawn.position, shotSpawn.rotation) as GameObject;
            shoot.transform.localScale = new Vector3(shotSpawn.localScale.x, shotSpawn.localScale.y, shotSpawn.localScale.z);
            Rigidbody arrowShot = shoot.GetComponent<Rigidbody>();
            arrowShot.AddForce(Vector3.forward * speed);

        }
#endif

		//Camera follow
		playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, transform.position + cameraOffset, Time.deltaTime * 7.4f);
		playerCamera.transform.LookAt(transform);
	}

	void MoveToTarget(Vector2 posOnScreen)
	{
		//print("Move To: " + new Vector2(posOnScreen.x, Screen.height - posOnScreen.y));

		Ray screenRay = playerCamera.ScreenPointToRay(posOnScreen);

		RaycastHit hit;
		if (Physics.Raycast(screenRay, out hit, 75))
		{
			agent.destination = hit.point;

            //Show marker where we clicked
            if (targetObject)
			{
				targetObject.transform.position = agent.destination;
				targetObject.SetActive(true);
			}
		}
	}
}