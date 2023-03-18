using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pManager1 : MonoBehaviour
{
    //how to fix baked light settings: https://stackoverflow.com/questions/42447869/objects-in-scene-dark-after-calling-loadscene-loadlevel#:~:text=Try%20Clearing%20Baked%20Data%20if,which%20looks%20fine%20although%20SceneManager.
    // Start is called before the first frame update
    public void nextScene() {
        SceneManager.LoadScene("TESTING_1");
    }
}
