using UnityEngine;

public class Charge : MonoBehaviour {

    StageObject _StageObject;
    private bool TouchCharge;
    private Player player;

    void Start() {
        player = _StageObject.GetPlayer().GetComponent<Player>();
        TouchCharge = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "player") TouchCharge = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "player") TouchCharge = false;
    }

    void Update() {
        if (player.RecvInput && Input.GetKeyDown(player.Press)) {
            ChargeStart();
        }
    }

    private void ChargeStart() {
        player.RecvInput = false;
        player.gameObject.GetComponent<Animator>().SetBool("Charge", true);
        //Add event "ChargeOver" in Animation
    }

    public void ChargeOver() {
        player.RecvInput = true;
        player.gameObject.GetComponent<Animator>().SetBool("Charge", false);
        player.ElecQuan = 3;
    }

}
