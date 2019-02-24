using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMonster : MonoBehaviour {

    
    private float left, right;
    [HideInInspector] public int state;//怪物的状态。
    private RaycastHit2D check;
    private int onMonster = 0;
    private Vector2 velo = new Vector2(1, 0);
    [SerializeField] private GameObject check1;
    [HideInInspector] public float timeFlag;
    // Use this for initialization
	void Start () { 
        state = 0;
	}

    private void Update()
    {
        if (state != 2) onMonster = 0;
        if (state == 0 )
        {
            GetComponent<Rigidbody2D>().velocity = velo * Time.deltaTime * 400;
            check = Physics2D.Raycast(check1.transform.position, velo);
            if(check.distance <0.1f&& check.transform.tag != "Player" )
            {
                state = 1;velo *= -1;
                Vector3 scale = transform.localScale ;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        else if(state == 1 )
        {
            GetComponent<Rigidbody2D>().velocity = velo * Time.deltaTime * 400;
            check = Physics2D.Raycast(check1.transform.position, velo);
            
            if (check.distance < 0.1f && check.transform.tag!="Player")
            {
                state = 0; velo *= -1;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        else if(state == 2 &&onMonster==0 )
        {
            Debug.Log("缩成乌龟");
            if(Time.time>timeFlag)
            {
                playback();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onMonster = 1;
            
        }
        else onMonster = 0;
        if ((collision.gameObject.tag =="Player" || collision.gameObject.tag=="Bullet")&&state!=2 )
        {
            collision.gameObject.GetComponent<Player>().Injure();
            state = 2;
            timeFlag = Time.time + 5.5f;
        }
    }
    public void playback()
    {
        Debug.Log("恢复");
        this.GetComponent<Rigidbody2D>().gravityScale = 50;
        state = 0;
    }
}
