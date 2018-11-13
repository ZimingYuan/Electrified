using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripping : MonoBehaviour {

    // Editor: Syx
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

    void Update () {
		if(Time.time>timeFlag)
        {
            Instantiate(drip, posi.transform.position, Quaternion.identity);
            timeFlag = Time.time + cd;
        }
	}
}
