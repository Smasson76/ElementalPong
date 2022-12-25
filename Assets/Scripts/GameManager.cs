using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;     //Creating a singleton of this object

    public GameObject playerPrefab;

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
