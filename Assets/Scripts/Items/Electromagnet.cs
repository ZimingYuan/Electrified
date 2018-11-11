using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electromagnet : MonoBehaviour {

    // Editor: Yzm
    private bool IsOn, Touch;
    [SerializeField] private StageObject _StageObject;
    private Player player;

    void Start() {
        IsOn = false; Touch = false;
        player = _StageObject.GetPlayer().GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") Touch = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") Touch = false;
    }

    void Update() {
        if (Touch && player.RecvInput && Input.GetKeyDown(player.Press)) {
            if (IsOn) {
                Physics2D.gravity = new Vector2(0, -9.8f); IsOn = false;
            }
            else {
                Physics2D.gravity = new Vector2(0, 9.8f); IsOn = true;
            }
        }
    }

}
