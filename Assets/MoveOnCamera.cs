using UnityEngine;
using System.Collections;

public class MoveOnCamera : MonoBehaviour {

    public string inputH;
    public string inputV;
    

    public float forceStrength = 4;

    float angle;

    public GameObject cam;
    private Camera cam1;
    //private Transform ts;

    public float zoomRate;

    private Rigidbody2D rb;

    public int flipH = 1;

    public float mult = 1;


    public bool forceWall = false;



    // I basically take the input and turn it into angles then add the force to the character using the 
    // angles plus the angle that the camera is rotated.

    void Start()
    {

        //ts = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        cam1 = cam.GetComponent<Camera>();

        //trying to get it working again after a while.
        //camts = cam.GetComponent<Transform>();

        //cam.transform.localRotation.eulerAngles.x
    }


    void Update()
    {
        //Debug.Log(cam.transform.rotation.w + ", " + cam.transform.rotation.x + ", " + cam.transform.rotation.y + ", " + cam.transform.rotation.z);
        //Debug.Log(cam.transform.rotation.eulerAngles.x + ", " + cam.transform.rotation.eulerAngles.y + ", " + cam.transform.rotation.eulerAngles.z);



        //if (Input.GetAxisRaw(inputV) >= 0)
        //{
        //angle =  Mathf.Atan(Input.GetAxisRaw(inputH) / Input.GetAxisRaw(inputV)) / Mathf.PI;
        //}
        //else {
        //    angle = Mathf.Atan(Input.GetAxisRaw(inputH) / Input.GetAxisRaw(inputV)) / Mathf.PI;
        //}

        //Debug.Log("input Raw: " + Input.GetAxisRaw(inputH) + ", " + Input.GetAxisRaw(inputV));

        if (Input.GetAxisRaw(inputH) != 0 || Input.GetAxisRaw(inputV) != 0)
        {

            if (Input.GetAxisRaw(inputV) >= 0)
            {
                angle = Mathf.Atan(Input.GetAxisRaw(inputH) * flipH / Input.GetAxisRaw(inputV)) / Mathf.PI;
            }
            else
            {
                angle = 1 + Mathf.Atan(Input.GetAxisRaw(inputH) * flipH / Input.GetAxisRaw(inputV)) / Mathf.PI;
            }
            Debug.Log(angle);
            rb.AddForce(new Vector2(forceStrength * Mathf.Sin( (-cam.transform.rotation.eulerAngles.z / 180 + angle) * Mathf.PI), forceStrength * Mathf.Cos((-cam.transform.rotation.eulerAngles.z / 180 + angle) * Mathf.PI)));
        }





        // if you set the public bool to true for the level and your in the right spot you get pushed

        if (forceWall)
        {
            if (rb.position.x > 20 && rb.position.x < 40 && rb.position.y > -10 && rb.position.y < 10)
            {
                rb.AddForce(new Vector2( -3.0f * forceStrength , 0) );
            }
        }




        //Debug.Log(cam.transform.rotation.eulerAngles.z);

        //Debug.Log("angle: " + angle);
        //Debug.Log("sin,cos: " + Mathf.Sin(cam.transform.rotation.eulerAngles.z) + ", " + Mathf.Cos(cam.transform.rotation.eulerAngles.z));

        //rb.AddForce(new Vector2(Input.GetAxisRaw(inputH) * forceStrength , Input.GetAxisRaw(inputV) * forceStrength ));


        //rb.AddForce(new Vector2(forceStrength * Mathf.Sin(angle * Mathf.PI), forceStrength * Mathf.Cos(angle * Mathf.PI)));


        //Mathf.Sin(angle* Mathf.PI)
        // addforce at angle plus cam rotation z

    }   //end of fixed update





    // if the player is triggering the grow collider the camera zooms out and vice-versa

    void OnTriggerStay2D(Collider2D other)
    {
        try         // Give score to players when there's a red and a blue net
        {
            if (other.gameObject.CompareTag("Grow"))
            {
                cam1.orthographicSize += zoomRate/4;
            }else if (other.gameObject.CompareTag("GrowNot"))
            {
                cam1.orthographicSize -= zoomRate/4;
            }
        }
        catch
        {

        }
    }


}
