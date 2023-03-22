using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pManager : MonoBehaviour
{
    public GameObject player;
    //how to fix baked light settings: https://stackoverflow.com/questions/42447869/objects-in-scene-dark-after-calling-loadscene-loadlevel#:~:text=Try%20Clearing%20Baked%20Data%20if,which%20looks%20fine%20although%20SceneManager.
    // Start is called before the first frame update
    void Start()
    {
        // Check if the scene has been loaded from another scene
       
    
        
    }

    void ResetScene() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        
        foreach (GameObject obj in objects)
        {
            DestroyImmediate(obj);
        }
        SceneManager.LoadScene("TESTING");
    }

    public void nextScene() {
        SceneManager.LoadScene("TESTING_0");
    }

    public void nextSceneGlycolysis() {
        SceneManager.LoadScene("TESTING_1");
    }


    
}
