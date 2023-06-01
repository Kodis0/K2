using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 3f;        
    public float jumpHeight;
    public float turnSmoothTime = 0.1f;


    private Vector3 moveDirection;
    private float gravity = -9.81f;
    private bool isGrounded = false;
    private float turnSmoothVelocity;




    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }


    void Update()
    {
        isGrounded = controller.isGrounded;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = transform.right * horizontalInput * speed;

        
        moveDirection.y += gravity * Time.deltaTime;

       
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

       
        float verticalInput = Input.GetAxis("Vertical");
        moveDirection += transform.forward * verticalInput * speed;

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        }

       
        controller.Move(moveDirection * Time.deltaTime);
    }
}





