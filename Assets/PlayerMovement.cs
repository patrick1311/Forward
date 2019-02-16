using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 2f;
    private Vector3 movement;
    private float verticalVelocity = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;

        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        movement.y = verticalVelocity;
        movement.z = 1 * speed;
        controller.Move(movement * Time.deltaTime);
        
    }
}
