using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class CameraFollow : NetworkBehaviour
{
    public GameObject cameraHolder;
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset; 
    private Vector3 velocity = Vector3.zero;
    
    public override void OnNetworkSpawn()
    {
        cameraHolder.SetActive(IsOwner);
        base.OnNetworkSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            
        }
        
    }
}
