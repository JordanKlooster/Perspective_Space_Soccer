using UnityEngine;
using System.Collections;

public class switchFollow : MonoBehaviour {


    private Rigidbody2D rb;

    public GameObject cam;
    private CircularMotion cm;

    bool lifted = true;
	


    // this is the button, just have some checks for position and a gravity force applied so it goes back up.

	void Start () {

        rb = GetComponent<Rigidbody2D>();
        cm = cam.GetComponent<CircularMotion>();
	}
	
	
	void Update () {


        //Debug.Log(rb.position.y);
        try
        {
            if (rb.position.y < -31 && lifted)
            {
                lifted = false;
                cm.FollowP1 = !cm.FollowP1;
                Debug.Log("Lifted is now false");
            }
            else if (rb.position.y > -30.7 && !lifted)
            {
                lifted = true;
                Debug.Log("lifted is now true");
            }
        }
        catch
        {
            Debug.Log("id didn't work");
        }

    }
}
