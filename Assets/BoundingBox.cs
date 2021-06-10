using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    public float lowerX;
    public float upperX;
    public float lowerY;
    public float upperY;
    public float lowerZ;
    public float upperZ;

    public GameObject director;

    Vector3 cur_location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hitWall = false;
        //get the current location
        cur_location = director.transform.position;

        if (director.transform.position.x < lowerX)
        {
            cur_location.x = lowerX;
            director.transform.position = cur_location;
            hitWall = true;
        }
        if (director.transform.position.x > upperX)
        {
            cur_location.x = upperX;
            director.transform.position = cur_location;
            hitWall = true;
        }
        if (director.transform.position.y < lowerY)
        {
            cur_location.y = lowerY;
            director.transform.position = cur_location;
            hitWall = true;
        }
        if (director.transform.position.y > upperY)
        {
            cur_location.y = upperY;
            director.transform.position = cur_location;
            hitWall = true;
        }
        if (director.transform.position.z < lowerZ)
        {
            cur_location.z = lowerZ;
            director.transform.position = cur_location;
            hitWall = true;
        }
        if (director.transform.position.z > upperZ)
        {
            cur_location.z = upperZ;
            director.transform.position = cur_location;
            hitWall = true;
        }

        if (hitWall == true) {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            hitWall = false;
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch); // turn off vibratrion
        }
    }

}
