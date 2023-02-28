using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class customGrab : MonoBehaviour
{
    // Reference to the Interactable component
    private Interactable interactable;
    
    // The point on the object where the hand should grab it
    public Transform grabPoint;

    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand) {
        hand.ShowGrabHint();
    }

    private void OnHandHoverEnd(Hand hand) {
        hand.HideGrabHint();
    }

    private void HandHoverUpdate(Hand hand) {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabType != GrabTypes.None) {
            // Calculate the distance and rotation between the hand and the grab point
            Vector3 handOffset = hand.transform.position - grabPoint.position;
            Quaternion handRotationOffset = Quaternion.Inverse(grabPoint.rotation) * hand.transform.rotation;

            // Attach the object to the hand at the grab point
            hand.AttachObject(gameObject, grabType, Hand.AttachmentFlags.DetachFromOtherHand, grabPoint);

            // Set the position and rotation of the object relative to the grab point
            gameObject.transform.position = grabPoint.position + handOffset;
            gameObject.transform.rotation = handRotationOffset * grabPoint.rotation;

            // Lock the hand to the object and hide the grab hint
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        } else if (isGrabEnding) {
            // Detach the object from the hand and unlock the hand
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}
