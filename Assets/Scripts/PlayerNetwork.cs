using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;
using UnityEngine.AI;

public class PlayerNetwork : NetworkBehaviour
{
    public NavMeshAgent agent;

    public float speed; 

    public Transform playerTransform;

    public Camera playerCamera;

    public float rotateSpeedMovement = 0.05f;

    private float rotateVelocity;

    
    void Update(){
        if(!IsOwner)return;
        Move();
    }

    public void Move() {
        if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;

            if(Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) {
                if(hit.collider.tag == "Ground") {
                    agent.SetDestination(hit.point);
                    agent.stoppingDistance = 0;

                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - playerTransform.position);
                    float rotationY = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                    playerTransform.eulerAngles = new Vector3(0, rotationY, 0);
                }
            }
        }
    }
}
