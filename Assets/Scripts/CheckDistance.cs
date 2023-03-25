using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
    {
        public void PlayerWithinDistance()
        {
            Debug.Log("Player is within 2 meters of " + gameObject.name);
            // Do something when player is within 2 meters
        }

        public void PlayerOutOfRange()
        {
            Debug.Log("Player is out of range of " + gameObject.name);
            // Do something when player is out of range
        }
    }
