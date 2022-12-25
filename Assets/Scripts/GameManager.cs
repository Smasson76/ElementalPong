using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;     //Creating a singleton of this object

    void Awake() {
        //If this Gamemanager does not exist, set this instance and don't destroy, else destroy
        if (instance == null) {
			instance = this;
            DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(gameObject);
		}
    }
}
