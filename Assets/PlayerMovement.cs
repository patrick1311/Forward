using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 3f;
    private Vector3 movement;
    private float verticalVelocity = 0.0f;
    public static Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        initPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        //update x
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        //update y
        movement.y = verticalVelocity;
        //update z
        //movement.z = speed;

        controller.Move(movement * Time.deltaTime);
        
    }

    public float getSpeed() { return speed; }
}
