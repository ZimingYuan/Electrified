using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterVelocity : MonoBehaviour {

    // Editor: Syx
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -200));
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Player")
        {
            collision.gameObject.GetComponent<Player>().Injure();
        }
        Destroy(gameObject);
    }

}
