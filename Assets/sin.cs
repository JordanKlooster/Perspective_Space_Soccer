using UnityEngine;
using System.Collections;

public class sin : MonoBehaviour {

	//private Transform ts;
    private Rigidbody2D rb;

    public float rate;
    public float amplitude;
    public float delay;




    // This is the Script for the blocks that go up and down using a sin wave over time.
    // just adding force, and I have a public delay variable so the two boxer weren't in sync.

    void Start () {
        //ts = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        //Time.deltaTime
        //Time.fixedTime;

        //ts.position = new Vector3( ts.position.x, Mathf.Sin(Time.fixedTime), ts.position.z );
        //rb.position = new Vector2( rb.position.x, Mathf.Sin(Time.fixedTime) );
        rb.AddForce(new Vector2( 0, Mathf.Sin( (Time.fixedTime + delay) / rate) * amplitude ));

	}
}
