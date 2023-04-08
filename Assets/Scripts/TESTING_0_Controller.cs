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
    public List<Transform> randomPositions; // The list of positions to randomly assign to the objects

    public Dictionary<string, Vector3> originalPositions = new Dictionary<string, Vector3>(); // A dictionary to store the original positions of the objects
    private List<Vector3> usedPositions = new List<Vector3>(); // A list to store the positions that have already been used


    void Start()
    {
        // Store the original positions of the objects
        foreach (Transform child in transform)
        {
            originalPositions.Add(child.tag, child.transform.position);
        }

        // Randomly assign positions to the objects
        foreach (Transform child in transform)
        {
            Vector3 randomPos = GetRandomPosition();
            child.position = randomPos;
            usedPositions.Add(randomPos);
        }
    }
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

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPos = randomPositions[Random.Range(0, randomPositions.Count)].position;

        while (usedPositions.Contains(randomPos))
        {
            randomPos = randomPositions[Random.Range(0, randomPositions.Count)].position;
        }

        return randomPos;
    }
    
    void ResetScene() {
        Object[] objects = FindObjectsOfType(typeof(GameObject));

        
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void returnToMenu() {
        SceneManager.LoadScene("TESTING_NETWORK");
        
    }
}
