using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 400f;
    public Rigidbody _rb;
    public Camera mainCamera;
    public Transform orientation;

    //Dash
    public float dashForce = 2f;
    public float dashCount = 1f;

    public float dashCooldown = 5f;
    private float dashTimer = 0;

    [SerializeField] private DashBar dashBar;

    private void Start() {
        //load stats
        speed = StaticData.playerSpeed;
        dashForce = StaticData.playerDashForce;
        dashCooldown = StaticData.playerDashCooldown;
    }
    private void Update() {
        if(dashTimer > 0) dashTimer -= Time.deltaTime;
        //Dash
        if(Input.GetMouseButtonDown(1)) {
            Dash();
        }
        dashBar.UpdateDashBar(dashCooldown, dashCooldown - dashTimer);

        //update stats
        StaticData.playerSpeed = speed;
        StaticData.playerDashForce = dashForce;
        StaticData.playerDashCooldown = dashCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(inputX, 0.0f, inputY);
        _rb.AddForce(movement.normalized * (speed/100));

        

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

    }
}

