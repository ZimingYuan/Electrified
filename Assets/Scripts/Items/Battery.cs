using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") collider.gameObject.GetComponent<Player>().BatteryNum++;
        Destroy(gameObject);
    }
}
