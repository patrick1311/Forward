using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public BoxCollider sideCol;

    private void Start()
    {
       // SetFrontCollider();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            collision.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerMovement.StopMovement();
            playerMovement.PushPlayer();

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
