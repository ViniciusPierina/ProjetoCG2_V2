using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotSpawn;
    public float fireRate;
    public float speed = 100f;
    public RotateToMouse mouse;

    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            SpawnArrow();
        }
    }

    void SpawnArrow()
    {
        nextFire = Time.time + fireRate;
        GameObject shoot = Instantiate(projectile, shotSpawn.position, mouse.GetRotation()) as GameObject;
        
        if(mouse != null)
        {
            shoot.transform.localRotation = mouse.GetRotation();
            //shoot.transform.rotation = mouse.GetRotation();

            shoot.transform.Rotate(0, 90, 0, Space.World);
        }
    }
}
