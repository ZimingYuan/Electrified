using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electromagnet : MonoBehaviour {

    Vector2 continuousPower = new Vector3(100, 0);
    private void OnTriggerStay2D(Collider2D collision)
    {
        Physics2D.gravity = new Vector2(0,-1);
    }
}
