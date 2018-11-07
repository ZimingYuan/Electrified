using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObject : MonoBehaviour {

    public List <GameObject> Doors = new List<GameObject>();
    public GameObject Player;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public GameObject OpticalSw;
    public GameObject LaserLauncher;
    //public HPPanel HPPanel;

    public GameObject GetDoorByColor(string color) {
        foreach (GameObject i in Doors) {
            if (i.GetComponent<Door>().Color == color) return i;
        }
        return null;
    }

    public GameObject GetPlayer() {
        return Player;
    }

}
