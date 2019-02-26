using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            collision.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerMovement.StopMovement();
            playerMovement.PushPlayer();

            //Stop environment from moving
            FindObjectOfType<GM>().EndRun();
        }
    }
}
