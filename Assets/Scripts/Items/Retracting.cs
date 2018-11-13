using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retracting : MonoBehaviour {

    // Editor: Syx
    public Player player;
    private float proportion;
    public GameObject gam;
    private void Start()
    {
        proportion = player.proportion;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.transform.tag=="bigger")//放大
        {
            collision.gameObject.transform.localScale *= proportion;
            collision.gameObject.transform.position = gam.transform.position;
        }
        if (gameObject.transform.tag == "smaller")//缩小
        {
            collision.gameObject.transform.localScale *= proportion;
            collision.gameObject.transform.position = gam.transform.position;
        }
    }
}
