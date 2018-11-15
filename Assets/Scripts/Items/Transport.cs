using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour {

    //editor: Yzm
    [SerializeField] private StageObject _StageObject;
    [SerializeField] private Vector3 AppearPosition;
    private bool Touch;
    private Player player;

    void Start () {
        Touch = false; player = _StageObject.GetPlayer().GetComponent<Player>();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Touch = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Touch = false;
    }

    void Update () {
		if (Touch && player.RecvInput && Input.GetKeyDown(player.Press)) {
            player.gameObject.transform.position = AppearPosition;
            //player.Change();
        }
	}
}
