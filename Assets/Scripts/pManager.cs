using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class pManager : MonoBehaviour
{
    public GameObject player;
    public SteamVR_Action_Boolean resetButton; 
    //how to fix baked light settings: https://stackoverflow.com/questions/42447869/objects-in-scene-dark-after-calling-loadscene-loadlevel#:~:text=Try%20Clearing%20Baked%20Data%20if,which%20looks%20fine%20although%20SceneManager.
    // Start is called before the first frame update
    void Start()
    {
        // Check if the scene has been loaded from another scene
       
        //ResetScene();
        
    }

    void Update() {
        //resets the scene upon pressing the reset button
        if (resetButton.stateDown) {
            Destroy(player);
            ResetScene();
        }
    }

    //find all objects in scene then destroys everything before reloading
    void ResetScene() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("TESTING_NETWORK");
    }

    //exit
    public void exitApp() {
        StopAllCoroutines();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
        Application.Quit();
    }

    //move to fermentation
    public void nextScene() {
        Destroy(player);
        SceneManager.LoadScene("TESTING_ROOM");
    }

    //move to glycolysis
    public void nextSceneGlycolysis() {
        SceneManager.LoadScene("TESTING_ROOM_2");
    }


    
}
