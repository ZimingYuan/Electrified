using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour {

    // Editor: Syx
    private Player player;
    private Door door;
    private bool Touch, IsOpen;
    public StageObject gameManagee;
    [SerializeField] private string color;
    // Use this for initialization
    void Start () {
        player = gameManagee.GetPlayer().GetComponent<Player>();
        Touch = IsOpen = false;
        door = gameManagee.GetComponent<StageObject>().GetDoorByColor(color).GetComponent<Door>();
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") Touch = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") Touch = false;
    }

    void Update () {
        if (Touch && player.RecvInput && Input.GetKeyDown(player.Press))
        {
            if(IsOpen)
            {
                Vector3 a = gameObject.transform.eulerAngles;
                a.z += 60; gameObject.transform.eulerAngles = a;
                door.CLOSE(); IsOpen = false;
            } else {
                Vector3 a = gameObject.transform.eulerAngles;
                a.z -= 60; gameObject.transform.eulerAngles = a;
                door.OPEN(); IsOpen = true;
            }
        }
	}
}
