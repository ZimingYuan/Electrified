using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpticalSw : MonoBehaviour {

    [SerializeField] private string color;
    [SerializeField] private Sprite stateOn;
    [SerializeField] private Sprite stateOff;
    [SerializeField] private StageObject _StageObject;
	
    public void On() {
        GetComponent<SpriteRenderer>().sprite = stateOn;
        Door door = _StageObject.GetDoorByColor(color).GetComponent<Door>();
        door.OPEN();
    }

    public void Off() {
        GetComponent<SpriteRenderer>().sprite = stateOff;
        Door door = _StageObject.GetDoorByColor(color).GetComponent<Door>();
        door.OFF();
    }

}
