using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    // Editor: Yzm
    private bool TouchMirror;
    private bool OnPress;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private StageObject _StageObject;
    private Player player;

    void Start() {
        TouchMirror = false;
        OnPress = false;
        player = _StageObject.GetPlayer().GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") TouchMirror = true;
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") TouchMirror = false;
    }

    void Update() {
        if (TouchMirror) {
            if (Input.GetKeyDown(player.Press)) OnPress = true;
            if (Input.GetKeyUp(player.Press)) OnPress = false;
            if (OnPress) {
                transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
            }
        }
    }
}
