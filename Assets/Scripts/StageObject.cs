using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageObject : MonoBehaviour {

    public List <GameObject> Doors = new List<GameObject>();
    public GameObject ActivePlayer;
    public GameObject PausePanel;
    public GameObject OpticalSw;
    public GameObject LaserLauncher;
    public GameObject LaserPrefab;
    public GameObject BulletPrefab;
    public SpriteRenderer Dark;
    public GameObject Lose;
    public GameObject Win;
    public HPPanel HPPanel;
    [HideInInspector]public int PlayerHP, ElecQuan, BatteryNum;
    [Header("滴水的间隔时间")]public float cd;
    [Header("游戏胜利所需要的电池数量")]public int ToWinNeedButteryNum;

    void Start() {
        PlayerHP = 3;//血量
        ElecQuan = BatteryNum = 0;//电量
        Physics2D.gravity = new Vector2(0, -9.8f);
    }

    public GameObject GetDoorByColor(string color) {
        foreach (GameObject i in Doors) {
            if (i.GetComponent<Door>().Color == color) return i;
        }
        return null;
    }

    public GameObject GetPlayer() {
        return ActivePlayer;
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
        SceneManager.LoadScene("Choose");
    }

}
