using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label_detect : MonoBehaviour
{
    public string correctTag; // set this in the Inspector window

    private void OnCollisionEnter(Collision other) {
        Debug.Log("collided --------------------------------------------");
        if (other.gameObject.tag == correctTag) {
            // molecule with correct tag has entered the boxed area
            Debug.Log("Correct molecule entered!");
            // add your own code here to handle the correct molecule entering
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag(correctTag)) {
            // molecule with correct tag has exited the boxed area
            Debug.Log("Correct molecule exited.");
            // add your own code here to handle the correct molecule exiting
        }
    }
}
