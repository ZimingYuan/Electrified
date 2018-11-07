using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Use this for initialization
    private Vector2 fly = new Vector2(1000, 0);
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = fly * Time.fixedDeltaTime;
    }
}
