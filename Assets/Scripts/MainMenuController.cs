using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Button vsHumanButton;
    public Button vsAIButton;
    public Button vsHumanOnlineButton;

    public void VsCpu() {
        //Do later
    }

    public void VsPlayer() {
        SceneManager.LoadScene(1);
    }

    public void OnlinePlay() {
        //Do later
    }
}




