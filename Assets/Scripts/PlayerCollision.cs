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
            //collision.collider.GetComponent<Rigidbody>().useGravity = true;
            //collision.collider.GetComponent<Rigidbody>().c = false;
            collision.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Debug.Log("Hit an obstacle");
            playerMovement.StopMovement();
            playerMovement.PushPlayer();

            //Stop environment from moving
            FindObjectOfType<GM>().EndRun();
        }
    }
}
