using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

     public static BallController instance;     //Creating a singleton of this object

    public float speed = 10f; // public variable to set the speed of the ball

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
        rb.velocity = Random.insideUnitSphere * speed;
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
    }

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.CompareTag("LeftBorder")) {
            GameManager.instance.Player1Scored();
        }
        if (c.gameObject.CompareTag("RightBorder")) {
            GameManager.instance.Player2Scored();
        }
    }
}
