using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public BoxCollider sideCol;
    public Animator playerAnim;

    private void Start()
    {
       // SetFrontCollider();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            //if hit on the side return

            //else end run
            //collision.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerMovement.StopMovement();
            playerMovement.PushPlayer();
            playerAnim.Play("walk");
            //Stop environment from moving
            FindObjectOfType<GM>().EndRun();
        }
    }
    /*
    void SetFrontCollider()
    {
        MeshCollider mesh = GetComponent<MeshCollider>();
        float x = mesh.bounds.size.x;
        float y = mesh.bounds.size.y;
        frontCollider.center = new Vector3(0, 0.5f, mesh.bounds.extents.z);
        frontCollider.size = new Vector3(x, y, 0.1f);
    }*/
}
