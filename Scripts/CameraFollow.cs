using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject target; //follow target
    // Start is called before the first frame update
    Transform AT; //camera Transform component
    void Start ()
    {
		target = GameObject.FindWithTag("Player");
        AT=target.transform;
    }
    //LateUpdate is called after the frame update
    void LateUpdate () {
        //change camera position to target position
        transform.position = new Vector3 (AT.position.x,AT.position.y,transform.position.z);
    }
}
