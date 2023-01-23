using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    [Header("Variables")]       //Public variables
    public float speed = 1f;    //Speed of players paddle
    public int playerNum = 0;

    //Player Variables
    public string[] Movement = new string[] { "Horizontal", "Horizontal2" };
    public static Dictionary<int, PaddleController> players = new Dictionary<int, PaddleController>();

    Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();

        players[playerNum] = this;
    }

    void Update() {

        float axisX = Input.GetAxisRaw(Movement[playerNum]);

        //Player 0 movement
        if (playerNum == 0) {
            if (axisX >= 0.1f) {
            anim.SetBool("isRight", true);
            }
            else {
                anim.SetBool("isRight", false);
            }

            if (axisX <= -0.01f) {
                anim.SetBool("isLeft", true);
            }
            else {
                anim.SetBool("isLeft", false);
            }
        }
        
        //Player 1 movement
        if (playerNum == 1) {
            if (axisX >= 0.1f) {
            anim.SetBool("isLeft", true);
            }
            else {
                anim.SetBool("isLeft", false);
            }

            if (axisX <= -0.01f) {
                anim.SetBool("isRight", true);
            }
            else {
                anim.SetBool("isRight", false);
            }
        }
        
        
        Vector3 heading = new Vector3(axisX, 0, 0);
        Vector3 velocity = heading * speed;
        transform.position = transform.position + velocity;
    }
}
