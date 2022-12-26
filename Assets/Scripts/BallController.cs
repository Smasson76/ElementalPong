using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    
    public float speed = 10;
    private Rigidbody body;

    void Start() {
        body = GetComponent<Rigidbody>();
        Launch();
    }

    void Launch() {
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float z = Random.Range(0,2) == 0 ? -1 : 1;
        body.velocity = new Vector3(speed * x, 0, speed * z);
    }
}
