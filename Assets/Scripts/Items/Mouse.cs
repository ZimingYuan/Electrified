using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    // Editor: Syx
    public float moveMax;//老鼠的移动范围
    public float moveMin;
    public int state=1;
    public StageObject gameManagee;
    public Sprite spl, sp2;//老鼠的两个状态
    private int flag = 1;//方向标记
    private float flagTime;//时间标记
    private GameObject Gam;
    [SerializeField]private Vector2 go = new Vector2(200, 0);
	
	void Update () {
       
        if(state==1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spl;
            GetComponent<Rigidbody2D>().velocity = flag * go * Time.deltaTime;
            Debug.Log(flag);
            if (gameObject.transform.position.x > moveMax - 0.5f)
            {
                flag = -1;
                gameObject.transform.localScale = new Vector3(-1, 1, 0);
            }
            if (gameObject.transform.position.x < moveMin + 0.5f)
            {
                flag = 1;
                gameObject.transform.localScale = new Vector3(1, 1, 0);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sp2;
            if (Time.time > flagTime)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spl;
                state = 1;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            state = 2;
            flagTime = Time.time + 5;//暂定+5秒
        }
        if(collision.gameObject.tag=="Player")
        {
            Gam = gameManagee.GetPlayer();
            Gam.GetComponent<Player>().Injure();
        }
    }
}
