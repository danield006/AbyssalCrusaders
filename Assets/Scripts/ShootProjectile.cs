using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask groundMask;

    public KeyCode key;

    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float fireForce = 20f;

    void start(){
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    private void Shoot(){
        if (Input.GetKeyDown(key)){
            var projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireForce;
        }
    }

    private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                var direction = position - transform.position;

                // You might want to delete this line.
                // Ignore the height difference.
                direction.y = 0;

                // Make the transform look in the direction.
                transform.forward = direction;
            }
        }

    private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }
}
