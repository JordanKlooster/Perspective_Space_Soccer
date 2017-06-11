using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public string inputH;
    public string inputV;

    public float forceStrength = 4;

    private Rigidbody2D rb;

	
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {

        rb.AddForce(new Vector2(Input.GetAxisRaw(inputH) * forceStrength, Input.GetAxisRaw(inputV) * forceStrength ) );

	}
}
