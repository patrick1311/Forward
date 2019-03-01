﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private MeshCollider mesh;
    private float speed = 4.8f;
    private Vector3 movement;
    private bool movementEnabled = true;
    private bool hasFinalPush = true;
    private float width;
    private float height;
    private Touch touch;
    public float jumpForce = 3;
    public float gravity = 20f;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementEnabled)
        {
            movement = Vector3.zero;
            //update x
            movement.x = Input.GetAxisRaw("Horizontal") * speed;

            /*
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
            if(Input.GetButton("Jump"))
            {
                movement.y = jumpForce;
            }
            */

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x > width)
                {
                    movement.x = speed;
                }
                else
                {
                    movement.x = -speed;
                }
            }

            //Prevent player clipping into other objects when move left and right
            if (SafeToMove(movement))
            //controller.Move(movement * Time.deltaTime);
            transform.Translate(movement * Time.deltaTime);
        }
        /*
        movement.y -= gravity * Time.deltaTime;
        if(SafeToMove(movement))
            controller.Move(movement * Time.deltaTime);
            */           
    }

    bool SafeToMove(Vector3 translation)
    {
        //check whether there is collider at the position player about to move to
        Collider[] cols = Physics.OverlapSphere(transform.position + translation * Time.deltaTime, mesh.bounds.extents.x);
        foreach (Collider col in cols)
        {
            if (col.tag == "SideBarrier" || col.tag == "Obstacle")
            {
                return false;
            }
        }
        return true;   
    }

    bool isGrounded()
    {
        Debug.Log(Physics.Raycast(transform.position, -Vector3.up, mesh.bounds.extents.y + 0.1f));
        return Physics.Raycast(transform.position, -Vector3.up, mesh.bounds.extents.y + 0.001f); ;
    }

    public void SetPlayerSpeed(float gameSpeed)
    {
        speed = gameSpeed * 0.6f;
        //Debug.Log("Player speed: " + speed);
    }

    public void StopMovement()
    {
        movementEnabled = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
    }

    //create dying animation
    public void PushPlayer()
    {
        if(hasFinalPush)
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 100 * speed);
            hasFinalPush = false;
        }
    }
}
