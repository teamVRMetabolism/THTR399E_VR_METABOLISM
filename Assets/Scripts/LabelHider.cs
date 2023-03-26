using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabelHider : MonoBehaviour
{
    //Transform player;
    public GameObject player;
    float distanceThreshold = 2.0f;
    void Start() {
        //player = GameObject.Find("Player").transform;

        // Loop through all TextMeshPro children and add a component to each one
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<CheckDistance>();
        }
        
        TextMeshPro[] textMeshPros = FindObjectsOfType<TextMeshPro>();

        foreach (TextMeshPro textMeshPro in textMeshPros)
        {
            textMeshPro.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check the distance between the player and each TextMeshPro child
        foreach (Transform child in transform)
        {
            CheckDistance checkDistance = child.GetComponent<CheckDistance>();

            float distance = Vector3.Distance(child.position, player.transform.position);
            //Debug.Log("Distance between player and " + child.name + ": " + distance);

            if (distance < distanceThreshold)
            {
                checkDistance.PlayerWithinDistance();
            }
            else
            {
                checkDistance.PlayerOutOfRange();
            }
        }
    }
}