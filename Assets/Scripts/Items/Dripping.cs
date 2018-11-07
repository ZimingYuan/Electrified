using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripping : MonoBehaviour {

    private float cd;
    private float timeFlag;
    public Player Player;
    [SerializeField] private GameObject drip;
    [SerializeField] private GameObject posi;//产生水滴的位置.
    private void Start()
    {
        timeFlag = 0;
        cd = Player.cd;
    }
    // Update is called once per frame
    void Update () {
		if(Time.time>timeFlag)
        {
            Instantiate(drip, posi.transform.position, Quaternion.identity);
            timeFlag = Time.time + cd;
        }
	}
}
