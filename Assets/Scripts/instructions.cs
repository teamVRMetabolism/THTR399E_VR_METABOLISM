using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class instructions : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;

    // Update is called once per frame
    void Update()
    {
        if (trigger.stateDown) {
            SceneManager.LoadScene("experiment");
        }
    }
}
