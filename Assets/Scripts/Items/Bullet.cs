using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Editor: Syx
    private Vector2 fly = new Vector2(1000, 0);
    public int sign;

    void Start() {
        gameObject.name = "Bullet";
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = sign * fly * Time.fixedDeltaTime;
    }
}
