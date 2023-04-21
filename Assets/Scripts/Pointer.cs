using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{

    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    public VRInputModule M_InputModule;

    private LineRenderer m_LineRenderer = null;
    private void Awake() {
        m_LineRenderer = GetComponent<LineRenderer>();

    }
    void Update()
    {
        UpdateLine();
    }

    private void UpdateLine() {
        //Use default or distance
        PointerEventData data = M_InputModule.GetData();
        float targetLenth = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength  :  data.pointerCurrentRaycast.distance;

        //Raycast
        RaycastHit hit = CreateRaycast(targetLenth);
        //default
        Vector3 endPosition = transform.position + (transform.forward * targetLenth);
        //or based on hit
        if(hit.collider != null) {
            endPosition = hit.point;
        }
        //set position of the dot
        m_Dot.transform.position = endPosition;
        //set linerenderer
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }

    //This method creates a raycast by shooting a ray from the position and forward direction of a transform,
// and returns information about the first object that the ray hits up to a specified length.
    private RaycastHit CreateRaycast(float length) {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);

        return hit;
    }
}
