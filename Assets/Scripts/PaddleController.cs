using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    [Header("Variables")]       //Public variables
    public float speed = 3f;    //Speed of players paddle
    public int playerNum = 0;

    //Player Variables
    public string[] Movement = new string[] { "Horizontal", "Horizontal2" };
    public static Dictionary<int, PaddleController> players = new Dictionary<int, PaddleController>();

    void Awake() {
        players[playerNum] = this;
    }

    void Update() {

        float axisX = Input.GetAxisRaw(Movement[playerNum]);
        
        Vector3 heading = new Vector3(axisX, 0, 0);
        Vector3 velocity = heading * speed;
        transform.position = transform.position + velocity;
    }
}
