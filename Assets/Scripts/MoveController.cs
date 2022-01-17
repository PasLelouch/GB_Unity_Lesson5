using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float Jumpspeed;
    private bool groundedPlayer;
    Vector3 move;
    float gravityValue = -9.81f;
    void Start()
    {
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && move.y < 0)
        {
            move.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
    


        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {

            move.y += Mathf.Sqrt(Jumpspeed * -3.0f * gravityValue);

        }
        move.y += gravityValue * Time.deltaTime;
        controller.Move(move * Speed *  Time.deltaTime);


    }
}
