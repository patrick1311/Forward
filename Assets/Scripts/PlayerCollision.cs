using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator playerAnim;
    public ParticleSystem collisionParticle;

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            collision.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            collisionParticle.transform.position = playerMovement.transform.position;
            collisionParticle.Play();
            playerMovement.StopMovement();
            playerMovement.PushPlayer();
            playerAnim.Play("walk");
            //Stop environment from moving
            FindObjectOfType<GM>().EndRun();
        }
    }
}
