using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int sign;

    void Start() {
        gameObject.name = "Bullet";
        sign = 1;
    }
    private void Update()
    {
        if (gameObject.transform.localScale.x < 0) sign = -1;
    }
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right*1000*Time.deltaTime*sign;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Monster")
        {
            Debug.Log("碰到了");
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 50;
            collision.gameObject.GetComponent<PlatformMonster>().state = 2;
            collision.gameObject.GetComponent<PlatformMonster>().timeFlag = Time.time + 5.5f;
        }
        if(collision.gameObject.tag!="Player")
            Destroy(this.gameObject);
    }
}
