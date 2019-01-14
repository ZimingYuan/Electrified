using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMonster : MonoBehaviour {

    
    private float left, right;
    private int state;//怪物的状态。
    private RaycastHit2D check;
    private Vector2 velo = new Vector2(1, 0);
    [SerializeField] private GameObject check1;
    private float timeFlag;
    // Use this for initialization
	void Start () { 
        state = 0;
	}

    private void Update()
    {
        if(state == 0 )
        {
            GetComponent<Rigidbody2D>().velocity = velo * Time.deltaTime * 50;
            check = Physics2D.Raycast(check1.transform.position, velo);
            if(check.distance <0.1f )
            {
                state = 1;velo *= -1;
                Vector3 scale = transform.localScale * -1;
                transform.localScale = scale;
            }
        }
        else if(state == 1 )
        {
            GetComponent<Rigidbody2D>().velocity = velo * Time.deltaTime * 50;
            check = Physics2D.Raycast(check1.transform.position, velo);
            if (check.distance < 0.1f)
            {
                state = 0; velo *= -1;
                Vector3 scale = transform.localScale * -1;
                transform.localScale = scale;
            }
        }
        else if(state == 2 )
        {
            Debug.Log("缩成乌龟");
            if(Time.time>timeFlag)
            {
                playback();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("碰到了");
        if(state!=2)
        {
            collision.gameObject.GetComponent<Player>().Injure();
        }
        state = 2;
        timeFlag = Time.time + 5.5f;
    }
    public void playback()
    {
        Debug.Log("恢复");
        state = 0;
    }
}
