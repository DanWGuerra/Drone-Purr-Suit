using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronController : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float drift = 0.9f;
    [SerializeField] private bool player2;

    private Vector3 velocity;

    void Update()
    {
        if (player2)
            ControlesP2();
        else
            ControlesP1();
    }

    void ControlesP1()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 moveDirection = inputVector.normalized;

        // Accelerate
        if (moveDirection != Vector3.zero)
        {
            velocity += moveDirection * acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            // Decelerate
            velocity = Vector3.Lerp(velocity, Vector3.zero, drift * Time.deltaTime);
        }

        transform.position += velocity * Time.deltaTime;

        // Smooth rotation towards the direction
        if (velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }

    void ControlesP2()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.I)) verticalInput += 1;
        if (Input.GetKey(KeyCode.K)) verticalInput -= 1;
        if (Input.GetKey(KeyCode.J)) horizontalInput -= 1;
        if (Input.GetKey(KeyCode.L)) horizontalInput += 1;

        Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 moveDirection = inputVector.normalized;

        // Accelerate
        if (moveDirection != Vector3.zero)
        {
            velocity += moveDirection * acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            // Decelerate
            velocity = Vector3.Lerp(velocity, Vector3.zero, drift * Time.deltaTime);
        }

        transform.position += velocity * Time.deltaTime;

        // Smooth rotation towards the direction
        if (velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}
