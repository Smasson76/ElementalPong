using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public static BallController instance;     //Creating a singleton of this object

    public float originalSpeed = 10f;
    public float speed = 10f; // public variable to set the speed of the ball
    public float speedMultiplier = 0.1f;

    private Rigidbody rb; // reference to the Rigidbody component of the ball

    public float bounciness = 1f; // reference to the Rigidbody component

    void Awake() {
        if (instance == null) {
			instance = this;
            DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
        
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>(); 

        Vector3 velocity = new Vector3(0.0f, 0.0f, Random.Range(-6.0f, -1.0f));
        rb.AddForce(velocity * speed);
    }

    void Update() {
        if (GameManager.instance.gameStarted == true) {
            Vector3 v = rb.velocity;
            if (v.magnitude < 0.1f) {
                v = Vector3.up * speed;
            }
            if (Mathf.Abs(Vector3.Dot(v.normalized, Vector3.right)) > 0.9f) {
                v.y *= 1.1f;
            }
            rb.velocity = v.normalized * speed;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.contacts.Length > 0) {
            transform.up = collision.contacts[0].normal;
        }

        if (collision.gameObject.CompareTag("Player")) {
            speed += speedMultiplier;
            rb.AddForce(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.CompareTag("LeftBorder")) {
            GameManager.instance.Player1Scored();
            speed = originalSpeed;
        }
        if (c.gameObject.CompareTag("RightBorder")) {
            GameManager.instance.Player2Scored();
            speed = originalSpeed;
        }
    }
}
