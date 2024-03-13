using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 400f;
    public Rigidbody _rb;
    public Camera mainCamera;
    public Transform orientation;

    //Dash
    public float dashForce = 2f;
    public float dashDuration = 2f;

    public float dashCooldown = 5f;
    private float dashTimer = 0;

    private void Update() {
        if(dashTimer > 0) dashTimer -= Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(inputX, 0.0f, inputY);
        _rb.AddForce(movement.normalized * (speed/100));

        //Dash
        if(Input.GetMouseButtonDown(1)) {
            Dash();
        }

        //Face mouse
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.yellow);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void Dash() {
        if(dashTimer > 0) return;
        else dashTimer = dashCooldown;
        Vector3 forceToApply = orientation.forward * dashForce;
        _rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
    }
    
    private void ResetDash() {

    }
}

