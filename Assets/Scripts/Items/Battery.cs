using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    [SerializeField] private StageObject _StageObject;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") _StageObject.BatteryNum++;
        Destroy(gameObject);
    }
}
