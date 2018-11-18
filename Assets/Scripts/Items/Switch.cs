using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    // Editor: Syx
    public string color;
    private Door iDoor;
    public StageObject gameManagee;
    private int cnt;

    void Start() {
        iDoor = gameManagee.GetComponent<StageObject>().GetDoorByColor(color).GetComponent<Door>();
        cnt = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cnt == 0) {
            iDoor.OPEN();
            Color c = gameObject.GetComponent<SpriteRenderer>().color;
            c.a = 0; gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        cnt++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (cnt == 1) {
            iDoor.CLOSE();
            Color c = gameObject.GetComponent<SpriteRenderer>().color;
            c.a = 255; gameObject.GetComponent<SpriteRenderer>().color = c;
        }
        cnt--;
    }
}
