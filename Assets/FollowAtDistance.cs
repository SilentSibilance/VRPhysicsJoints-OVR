using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Translates motion in the x direction only, for a far cube. 
public class FollowAtDistance : MonoBehaviour
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
        follower_cur_pos.x = director.transform.position.x;
        follower.transform.position = follower_cur_pos;

        Debug.Log("dir position:  " + director.transform.position);
        Debug.Log("fol position: " + follower.transform.position);
        Debug.Log("cur pos: " + follower_cur_pos);
    }
}
