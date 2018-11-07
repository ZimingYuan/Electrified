using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public string color;
    private GameObject iDoor;
    public StageObject gameManagee;
    private void OnTriggerStay2D(Collider2D collision)
    {
        iDoor = gameManagee.GetDoorByColor(this.color);
        iDoor.GetComponent<Door>().OPEN();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        iDoor = gameManagee.GetDoorByColor(this.color);
        iDoor.GetComponent<Door>().CLOSE();
    }
}
