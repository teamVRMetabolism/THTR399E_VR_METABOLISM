using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class playerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public SteamVR_Action_Vector2 input2;
    public float speed = 2;
    // Update is called once per frame
    void Update()
    {
        //for player rig
        /*
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
        
        transform.position += speed * Time.deltaTime * new Vector3(0, input2.axis.y, 0); */

        
        //for camera rig
        Vector3 direction = Camera.main.transform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
        transform.position += speed * Time.deltaTime * new Vector3(0, input2.axis.y, 0);
    }
}
