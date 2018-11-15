using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlsetting : MonoBehaviour {

    [SerializeField] private GameObject Music;
    [SerializeField] private GameObject Stop;
    private void Start()
    {
        if (GameObject.Find("GameManager"))
        {
            DontDestroyOnLoad(Music);
        }
    }
    public void goNextScene()
    {
        SceneManager.LoadScene(1);
    }
    public void StopMusic()
    {
        Stop.SetActive(true);
        Music.GetComponent<AudioSource>().Pause();
    }
    public void ContinueMusic()
    {
        Stop.SetActive(false);
        Music.GetComponent<AudioSource>().Play();
    }
}
