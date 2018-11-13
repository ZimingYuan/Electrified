using UnityEngine;

public class Charge : MonoBehaviour {

    // Editor: Yzm
    StageObject _StageObject;
    private bool TouchCharge;
    private Player player;

    void Start() {
        player = _StageObject.GetPlayer().GetComponent<Player>();
        TouchCharge = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") TouchCharge = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") TouchCharge = false;
    }

    void Update() {
        if (player.RecvInput && Input.GetKeyDown(player.Press)) {
            ChargeStart();
        }
    }

    private void ChargeStart() {
        player.RecvInput = false;
        //player.gameObject.GetComponent<Animator>().SetBool("Charge", true);
    }

    //ChargeOver() method has been moved into player.cs

}
