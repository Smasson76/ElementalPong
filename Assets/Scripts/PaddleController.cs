using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    //Public variables
    public float speed = 3f;    //Speed of players paddle

    //Private Gameobjects
    Rigidbody body;             //Players rigidbody for physics movement

    void Start() {
        body = GetComponent<Rigidbody>();
    }

    void Update() {
        float x = Input.GetAxis("Horizontal");
        Vector3 heading = new Vector3(x, 0, 0);
        Vector3 velocity = heading * speed;
        transform.position = transform.position + velocity;
    }
}
