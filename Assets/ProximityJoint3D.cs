using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityJoint3D : MonoBehaviour
{
    // Move the object around  but confine it
    // to a given radius around a center point.
    // Twine line visually connects handle object and center point, but does not have physics sims. 

    // Twine cylinder y direction (length) must be half of ProximityJoint3D radius. 

    public GameObject centrePoint;
    public GameObject connectingTwine;
    public float radius;
    public OVRGrabbable grab;
    public OVRPlayerController OVRpc;


    Vector3 centrePt;
    Vector3 twinePt;
    Quaternion twineRot;

    private void Start()
    {
        centrePt = centrePoint.transform.position;
        twinePt = transform.position + ((centrePt - transform.position) / 2); // sets the twine line to have its center point between handle object and center point. 

        connectingTwine.transform.position = twinePt;

        //twineRot = new Quaternion();
    }

    /*
    void Update()
    {
        // Get the new position for the object.
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 newPos = transform.position + movement;

        // Calculate the distance of the new position from the center point. Keep the direction
        // the same but clamp the length to the specified radius.
        Vector3 offset = newPos - centrePt;
        transform.position = centrePt + Vector3.ClampMagnitude(offset, radius);
    }*/

    void FixedUpdate()
    {
        // Get the new position for the object.
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 newPos = transform.position;

        // Calculate the distance of the new position from the center point. Keep the direction
        // the same but clamp the length to the specified radius.
        Vector3 offset = newPos - centrePt;
        transform.position = centrePt + Vector3.ClampMagnitude(offset, radius);

        // Update the centre point of the connecting twine to be between the handle and the centre point
        // and set the rotation to match the direction of the vector between handle and centre point. 
        Vector3 twineDist = (centrePt - transform.position);
        twinePt = transform.position + (twineDist / 2);
        connectingTwine.transform.position = twinePt;

        // Set the twine rotation.
        twineDist = twineDist.normalized;
        var lookTwineRot = Quaternion.LookRotation(twineDist)* Quaternion.Euler(90, 0, 0);
        connectingTwine.transform.rotation = lookTwineRot;


        // QOL - Freeze the player's motion when they are grabbing a cube.
        // Helps reduce a whole bunch of weird behaviour. 
        // Probably helps reduce a lot of VR sickness and vestibular too. 
        bool grabbed = grab.isGrabbed;
        Debug.Log("the cube is grabbed: " + grabbed);
        if (grabbed == true)
        {
            OVRpc.EnableLinearMovement = false;
        }
        else
        {
            OVRpc.EnableLinearMovement = true;
        }
    }
}
