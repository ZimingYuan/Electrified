﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    // Editor: Syx
    public string color;
    private GameObject iDoor;
    public StageObject gameManagee;
    private void OnTriggerEnter2D(Collider2D collision)
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
