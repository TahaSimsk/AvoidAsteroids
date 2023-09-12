using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeedForce;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float tolerance;
    [SerializeField] PlayerHealth playerHealth;


    Camera mainCamera;
    Rigidbody rb;
    Vector3 direction;
    Vector3 touchWorldPos;
    


    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        GetTouchPosition();

        ChangePlayerLocation();

        RotateToVelocity();

        ResetZPositionWhenOffTrack();
    }

    void ResetZPositionWhenOffTrack()
    {
        
        if (transform.position.z < -0.1f || transform.position.z > 0.1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }


    void GetTouchPosition()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();


            touchWorldPos = mainCamera.ScreenToWorldPoint(touchPos);

            direction = touchWorldPos - transform.position;

            direction.z = 0;

            direction.Normalize();
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    void FixedUpdate()
    {

        Move();
    }

    void Move()
    {
        if (direction == Vector3.zero || playerHealth.isDead)
        {
            return;
        }

        rb.AddForce(direction * movementSpeedForce, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMoveSpeed);
    }

    void ChangePlayerLocation()
    {
        Vector3 originalPlayerPos = transform.position;

        Vector2 playerViewportPos = mainCamera.WorldToViewportPoint(transform.position);


        if (playerViewportPos.x >= 0.98)
        {
            originalPlayerPos.x = -originalPlayerPos.x + 1f;
            
        }

        if (playerViewportPos.x <= 0)
        {
            originalPlayerPos.x = -originalPlayerPos.x - 1f;
            
        }

        if (playerViewportPos.y >= 0.98)
        {
            originalPlayerPos.y = -originalPlayerPos.y + 1f;
            
        }

        if (playerViewportPos.y <= 0)
        {
            originalPlayerPos.y = -originalPlayerPos.y - 1f;
            
        }

        transform.position = originalPlayerPos;
    }


    void RotateToVelocity()
    {
        if (rb.velocity == Vector3.zero)
        {

            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

    }




}
