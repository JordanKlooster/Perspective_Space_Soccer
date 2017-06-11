using UnityEngine;
using System.Collections;

public class FarCam : MonoBehaviour {

    public GameObject red;
    public GameObject blue;

    private Transform rPos;
    private Transform bPos;

    private float xdist;
    private float ydist;
    private float dist;

    private float xdistOld;
    private float ydistOld;

    public float min;
    public float camMult;

    private Transform td;
    private Camera cam;
    // cam

    void Start () {
        rPos = red.GetComponent<Transform>();
        bPos = blue.GetComponent<Transform>();

        td = GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }
	
	
	void Update () {


        td.position = (rPos.position + bPos.position) / 2 + new Vector3(0,0,-10);

        try
        {
            xdist = rPos.position.x - bPos.position.x;
            ydist = rPos.position.y - bPos.position.y;
        }
        catch {
            Debug.Log("ERROR couldn't set xdist or ydist");
            Debug.Log("xdist, ydist, xdistOld, ydistOld" + xdist + ", " + ydist /*+ ", " + xdistOld + ", " + ydistOld*/);
        }

        //ydistOld = ydist;
        //xdistOld = xdist;


        dist = min + ((Mathf.Pow(xdist, 2) + Mathf.Pow(ydist * 2, 2)) / camMult);

        //Debug.Log("dist: " + dist);

        // camera zoom is proportional to character distance
        
        cam.orthographicSize = dist;

        //td.rotation = new Quaternion();
    }
}
