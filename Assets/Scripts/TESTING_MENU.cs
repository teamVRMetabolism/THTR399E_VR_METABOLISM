using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class TESTING_MENU : MonoBehaviour
{
    //public vars for trigger inputs
    public SteamVR_Action_Boolean input1;
    public SteamVR_Action_Boolean input2;
    public bool cango1;
    public bool cango2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if the triggers have been pressed twice
        if (input1.stateDown) {
            cango1 = true;
        } else if (input2.stateDown) {
            cango2 = true;
        }
        //load the network
        if (cango1 && cango2) {
            SceneManager.LoadScene("TESTING_NETWORK");
        }
    }
}
