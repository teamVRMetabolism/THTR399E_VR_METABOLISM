using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public class TESTING_0_Controller : MonoBehaviour
{
    public SteamVR_Action_Boolean resetButton; 
    public GameObject player;

    void Update()
    {
        if (resetButton.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            Destroy(player);
            ResetScene();
        }
    }

    void ResetScene()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("TESTING_0");
    }
}
