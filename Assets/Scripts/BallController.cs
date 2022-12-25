using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    
    public bool inPlay = false;
    public float speed = 10;

    Rigidbody body;

    void Start() {
        body = GetComponent<Rigidbody>();

        float rand = Random.Range(0, 1);
        
        if(rand == 0) {
            body.AddForce(new Vector3(0, -0.3f, -3f) * speed);
        } 
        else {
            body.AddForce(new Vector3(0, -0.3f, 3f) * speed);
        }
    }
}
