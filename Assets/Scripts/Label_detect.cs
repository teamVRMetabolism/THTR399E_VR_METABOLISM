using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label_detect : MonoBehaviour
{
    public string correctTag; // set this in the Inspector window
    public string correctTag2; // set this in the Inspector window

    
    private void OnCollisionEnter(Collision other) {
        Debug.Log("collided --------------------------------------------");
        if (other.gameObject.tag == correctTag || other.gameObject.tag == correctTag2) {
            // molecule with correct tag has entered the boxed area
            Debug.Log("Correct molecule entered!");

            Transform collidedMolecule = other.gameObject.transform;
            TESTING_0_Controller controller = GameObject.Find("SceneController").GetComponent<TESTING_0_Controller>();
            if (controller.originalPositions.ContainsKey(correctTag))
            {
                collidedMolecule.GetComponent<Rigidbody>().isKinematic = true;
                collidedMolecule.position = controller.originalPositions[correctTag];
            }
        } 
    }
}
