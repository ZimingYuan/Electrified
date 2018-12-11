using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlace : MonoBehaviour {

    [SerializeField] private StageObject _StageObject;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            Player player = collider.gameObject.GetComponent<Player>();
            if (_StageObject.BatteryNum == _StageObject.ToWinNeedButteryNum) player.win();
        }
    }

}
