using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBig : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
        transform.parent.gameObject.GetComponent<Mirror>().OnTriggerEnter2D(collider);
    }

    void OnTriggerExit2D(Collider2D collider) {
        transform.parent.gameObject.GetComponent<Mirror>().OnTriggerExit2D(collider);
    }
	
}
