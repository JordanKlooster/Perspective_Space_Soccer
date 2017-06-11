using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

    public GameObject follow;

    private Transform td;
    private Rigidbody2D rg;

    private Transform camTS;
    private Camera cam;

    //private float changeRot;

    public int max = 100;
    public int min = 6;
    public float sens = 1f;

    //public float zPos = -10;






    // ok follow the player, just copy the position to the camera, and the angular velocity 
    // changes the camera zoom inbetween 2 limits. There's also a public variable for sensitivity. 


    void Start () {
        camTS = GetComponent<Transform>();
        cam = GetComponent<Camera>();

        rg = follow.GetComponent<Rigidbody2D>();
        td = follow.GetComponent<Transform>();
        //changeRot = td.rotation.eulerAngles.z;
    }
	
	
	void Update () {
        camTS.position = td.position + new Vector3(0,0,camTS.position.z);

        if ( (rg.angularVelocity < 0 && cam.orthographicSize >= min) || (rg.angularVelocity > 0 && cam.orthographicSize <= max) ) {
            cam.orthographicSize += rg.angularVelocity * sens / 2600;
        }
        /*
        Debug.Log("amount changed: " + (changeRot - td.rotation.eulerAngles.z) );
        if ((changeRot - td.rotation.eulerAngles.z) < 100 && (changeRot - td.rotation.eulerAngles.z) > -100) {
            Camera.current.orthographicSize += (changeRot - td.rotation.eulerAngles.z) / 180;
        }
        changeRot = td.rotation.eulerAngles.z;
        */

        //Camera.current.orthographicSize += ;
	}
}
