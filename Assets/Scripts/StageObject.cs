using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageObject : MonoBehaviour {

    public List <GameObject> Doors = new List<GameObject>();
    public GameObject Player;
    public GameObject PausePanel;
    public GameObject OpticalSw;
    public GameObject LaserLauncher;
    public GameObject LaserPrefab;
    public GameObject BulletPrefab;
    public SpriteRenderer Dark;
    public GameObject Lose;
    public GameObject Win;
    public HPPanel HPPanel;

    public GameObject GetDoorByColor(string color) {
        foreach (GameObject i in Doors) {
            if (i.GetComponent<Door>().Color == color) return i;
        }
        return null;
    }

    public GameObject GetPlayer() {
        return Player;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重载本场景
    }

    public void Quit()
    {
        SceneManager.LoadScene("start");
    }

    public void Gonext()
    {
        SceneManager.LoadScene(2);
    }

}
