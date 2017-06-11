using UnityEngine;
using System.Collections;

public class aspectRatio : MonoBehaviour {


    public float f = 1f;
    private Camera hi;




    // I added this script so that each level would change size based on the ascpect ratio.
    // the wider the aspect ration the more zoomed in you are.
	
	void Start () {
        hi = GetComponent<Camera>();
        hi.orthographicSize = hi.orthographicSize * (1.77778f / hi.aspect) * f ;

    }
	
	
	
}
