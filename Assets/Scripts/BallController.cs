using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // public variable to set the speed of the ball

    private Rigidbody rb; // reference to the Rigidbody component of the ball

    public float bounciness = 1f; // reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        // Set the ball's velocity to a random vector inside the unit sphere, multiplied by the speed
        rb.velocity = Random.insideUnitSphere * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get the normal of the collision surface
        Vector3 normal = collision.contacts[0].normal;

        // Reflect the ball's velocity off the collision surface
        rb.velocity = Vector3.Reflect(rb.velocity, normal) * bounciness;

    }

}
