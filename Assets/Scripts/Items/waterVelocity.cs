using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 200));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
