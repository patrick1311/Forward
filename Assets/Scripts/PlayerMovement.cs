using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private float speed = 5f;
    private Vector3 movement;
    private float verticalVelocity = 0.0f;
    public static Vector3 initPos;
    private bool movementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        initPos = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementEnabled)
        {
            movement = Vector3.zero;
            //update x
            movement.x = Input.GetAxisRaw("Horizontal") * speed;
            //update y
            movement.y = verticalVelocity;
            //update z
            //movement.z = speed;
            transform.Translate(movement * Time.deltaTime);
            //controller.Move(movement * Time.deltaTime);
        }

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
        GetComponent<Rigidbody>().AddForce(0, 0, 700);
    }
}
