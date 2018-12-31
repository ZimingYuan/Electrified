using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageObject : MonoBehaviour {

    [Header("游戏中的门")] public List <GameObject> Doors = new List<GameObject>();
    [Header("玩家对象")]public GameObject ActivePlayer;
    [Header("暂停面板")]public GameObject PausePanel;
    [Header("接受激光器")]public GameObject OpticalSw;
    [Header("激光发射器")]public GameObject LaserLauncher;
    [Header("激光预制体")]public GameObject LaserPrefab;
    [Header("子弹预制体")]public GameObject BulletPrefab;
    [Header("黑暗区域")]public SpriteRenderer Dark;
    [Header("失败面板")]public GameObject Lose;
    [Header("胜利面板")]public GameObject Win;
    [Header("血量显示")]public HPPanel HPPanel;
    [HideInInspector]public int PlayerHP, ElecQuan, BatteryNum;
    [Header("游戏胜利所需要的电池数量")]public int ToWinNeedButteryNum;
    [Header("铁制物品")] public List <GameObject> MentalObject = new List<GameObject>();

    void Start() {
        Time.timeScale = 1;
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

    public void PauseGame() {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

}
