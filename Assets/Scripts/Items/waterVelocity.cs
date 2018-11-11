using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterVelocity : MonoBehaviour {

    // Editor: Syx
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -200));
	}
	
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") collider.gameObject.GetComponent<Player>().Injure();
        Destroy(gameObject);
    }

	void Update () {
		
	}
}
