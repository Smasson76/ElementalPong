using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;     //Creating a singleton of this object

    public AudioClip ballHitSound;
    public AudioClip pointScoredSound;

    void Awake() {
        //If this Gamemanager does not exist, set this instance and don't destroy, else destroy
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
