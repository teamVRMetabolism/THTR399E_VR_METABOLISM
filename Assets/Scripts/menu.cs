using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public static string input;
    private void Start() {
        input = "";
    }
    private void Update() {
        if (input != null && input != ""){
            SceneManager.LoadScene("Instructions");
            
        }
    }

    public void ReadStringInput(string s) {
        input = s;
        Debug.Log(s);
    }
}
