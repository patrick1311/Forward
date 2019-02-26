using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private float speed = 4.8f;
    private Vector3 movement;
    private bool movementEnabled = true;
    private bool hasFinalPush = true;
    private float width;
    private float height;
    private Touch touch;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
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

            if(Input.touchCount > 0)
            {
                //Vector2 pos = Input.GetTouch(0).position;
                if (Input.GetTouch(0).position.x > width)
                {
                    movement.x = speed;
                }
                else
                {
                    movement.x = -speed;
                }
            }

            transform.Translate(movement * Time.deltaTime);
        }

    }

    public void SetPlayerSpeed(float gameSpeed)
    {
        speed = gameSpeed * 0.6f;
        Debug.Log("Player speed: " + speed);
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
