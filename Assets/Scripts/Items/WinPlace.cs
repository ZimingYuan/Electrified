using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlace : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            Player player = collider.gameObject.GetComponent<Player>();
            if (player.BatteryNum == player.ToWinNeedButteryNum) player.win();
        }
    }

}
