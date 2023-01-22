using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // public variable to set the speed of the ball

    private Rigidbody2D rb; // reference to the Rigidbody2D component of the ball

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the reference to the Rigidbody2D component

        // Generate random angle in radians between 0 and 2*PI
        float randomAngle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);

        // Convert angle to a Vector2
        Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

        // Set the ball's velocity with the random direction and the desired speed
        rb.velocity = randomDirection * speed;
    }
}
