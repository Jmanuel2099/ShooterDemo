using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 10f;

    [Header("Gravity and jump")]
    private float gravity = -9.81f;
    Vector3 velocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private LayerMask groundMask;
    bool isGrounded;
    [SerializeField] private float jumpHeight = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * axisX + transform.forward * axisZ;

        characterController.Move(move * speed * Time.deltaTime);

        // Bellow two lines add gravity to the player
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) &&  isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
}
