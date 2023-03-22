using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public class TESTING_0_Controller : MonoBehaviour
{
    public SteamVR_Action_Boolean resetButton; 
    public SteamVR_Action_Boolean menuReturn;
    public GameObject player;

    void Update()
    {
        if (resetButton.stateDown) {
            Destroy(player);
            ResetScene();
        }
        if (menuReturn.stateDown) {
            Destroy(player);
            returnToMenu();
        }
    }

    void ResetScene() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("TESTING_0");
    }

    void returnToMenu() {
        SceneManager.LoadScene("TESTING");
        
    }
}
