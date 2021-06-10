using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAtDistanceVertical : MonoBehaviour
{
    public GameObject director;
    public GameObject follower;

    Vector3 follower_init_pos;
    Vector3 follower_cur_pos;

    // Start is called before the first frame update
    void Start()
    {
        follower_init_pos = follower.transform.position;
    }


    void Update()
    {
        Debug.Log(follower.transform.position);
        Debug.Log("every update");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follower_cur_pos = follower_init_pos;

        //If you allow the follower cube to clip through the box below, it glitches out and will start rotating. 
        //Code is require to ensure clipping does not happen.
        //A more elegant solution where on searches for nearby Rigidbodies could be possible, but semi-hardcoding for now. 
        //Ensure cube not moved below box (starting location)
        if (director.transform.position.y < follower_init_pos.y)
        {
            follower_cur_pos.y = follower_init_pos.y;
        }
        else
        {
            follower_cur_pos.y = director.transform.position.y;
        }

        follower.transform.position = follower_cur_pos;

        Debug.Log("dir position:  " + director.transform.position);
        Debug.Log("fol position: " + follower.transform.position);
        Debug.Log("cur pos: " + follower_cur_pos);
    }
}
