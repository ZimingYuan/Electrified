using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electromagnet : MonoBehaviour {

    // Editor: Yzm
    private bool Touch;
    [SerializeField] private StageObject _StageObject;
    private Player player;
    private GameObject Monster;

    void Start() {
        Touch = false;
        player = _StageObject.GetPlayer().GetComponent<Player>();
        Monster = _StageObject._Monster;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") Touch = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") Touch = false;
    }

    void Update() {
        if (Touch && player.RecvInput && Input.GetKeyDown(player.Press)) {
            if (Physics2D.gravity.y > 0) {
                Physics2D.gravity = new Vector2(0, -9.8f);
                Vector3 s = player.transform.localScale;
                s.y = -s.y;
                player.transform.localScale = s;
                if (Monster) {
                    Vector3 vec1 = Monster.transform.localScale;
                    vec1.y *= -1;
                    Monster.transform.localScale = vec1;
                }
            }
            else {
                Physics2D.gravity = new Vector2(0, 9.8f);
                Vector3 s = player.transform.localScale;
                s.y = -s.y;
                player.transform.localScale = s;
                if (Monster) {
                    Vector3 vec1 = Monster.transform.localScale;
                    vec1.y *= -1;
                    Monster.transform.localScale = vec1;
                }
            }
        }
    }

}
