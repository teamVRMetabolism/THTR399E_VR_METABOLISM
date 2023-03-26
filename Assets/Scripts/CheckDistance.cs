using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckDistance : MonoBehaviour
    {
        TextMeshPro textMeshPro;

        void Start()
        {
            textMeshPro = GetComponent<TextMeshPro>();
        }

        public void PlayerWithinDistance()
        {
            textMeshPro.enabled = true;
        }

        public void PlayerOutOfRange()
        {
            textMeshPro.enabled = false;
        }
    }
