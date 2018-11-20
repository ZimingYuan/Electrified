using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlsetting : MonoBehaviour
{

    [SerializeField] private GameObject Music;
    private GameObject go;//获取当前音乐
    [SerializeField] private GameObject Stop;//音乐停止
    [SerializeField] private GameObject Sta;//音乐开始
    private void Start()
    {
        if (!GameObject.Find("MusicGround(Clone)"))
        {
            Instantiate(Music);
            go = GameObject.Find("MusicGround(Clone)");
            DontDestroyOnLoad(go);
        }
    }
    public void goNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void StopMusic()
    {
        Stop.SetActive(true);
        Sta.SetActive(false);
        go.GetComponent<AudioSource>().Pause();
    }
    public void ContinueMusic()
    {
        Stop.SetActive(false);
        Sta.SetActive(true);
        go.GetComponent<AudioSource>().Play();
    }
}
