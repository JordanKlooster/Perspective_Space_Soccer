using UnityEngine;
using System.Collections;

public class CircularMotion : MonoBehaviour {


    private Transform tr;
    private Rigidbody2D rb;

    public GameObject p1;
    public GameObject p2;

    public Rigidbody2D r1;
    public Rigidbody2D r2;


    public float r = 2.5f;
    float angle;
    float angularSpeed; // in degrees per second
    Vector3 center = new Vector3(0,0,0);

    float angleSpace;

    public float mult = 30;

    //float mouseLean = 0.2f;
    //float newR = 0;

    //float time;
    public bool FollowP1;





    // The camera moves based on the given angle, I get the angle based on some math determining the 
    // angle from (o,o) and I swap out the characters if you press the button.

    void Start () {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();


        r1 = p1.GetComponent<Rigidbody2D>();
        r2 = p2.GetComponent<Rigidbody2D>();


    }
	
	
	void FixedUpdate () {



        //This chooses wich player to follow;
        if (FollowP1) //gets angleSpace
        {
            GetAngle(r1.position.x, r1.position.y);
        }
        else
        {
            GetAngle(r2.position.x, r2.position.y);
        }





        rb.rotation = angleSpace * -180;




        angle = -rb.rotation / 180; //need angle in radians i think


        //Debug.Log("AS: " + angleSpace);
        //Debug.Log("An:  " + angle);




        

        tr.position = center + new Vector3( r * Mathf.Sin((1 + angle) * Mathf.PI), r * Mathf.Cos((1 + angle) * Mathf.PI), -10);

        
        //Debug.Log(angleSpace);

        

        
        

        // Current Problem: speed up and slow down
        // change size
        // change lean


    }


    void GetAngle(float x, float y)
    {
        if (y >= 0)
        {
            angleSpace = Mathf.Atan(x / y) / Mathf.PI;
        }
        else
        {
            angleSpace = 1 + Mathf.Atan(x / y) / Mathf.PI;
        }
    }

}



/*
if (ydist >= 0){
					angle = 1 + Mathf.Atan(xdist/ ydist)/Mathf.PI;
				}else{
					angle = Mathf.Atan(xdist/ ydist)/Mathf.PI;
				}
*/
