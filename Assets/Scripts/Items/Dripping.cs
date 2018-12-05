using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripping : MonoBehaviour {

    // Editor: Syx
    private float cd;
    private float timeFlag;
    [SerializeField] private StageObject _StageObject;
    [SerializeField] private GameObject drip;
    [SerializeField] private GameObject water1;
    [SerializeField] private GameObject water2;
    private void Start()
    {
        timeFlag = 0;
        cd = _StageObject.GetPlayer().GetComponent<Player>().cd;
    }

    void Update () {
		if(Time.time>timeFlag)
        {
            Instantiate(drip, water1.transform.position, Quaternion.identity);
            Invoke("Produce2", 0.5f);
            timeFlag = Time.time + cd;
        }
	}
    private void Produce2()
    {
        Instantiate(drip, water2.transform.position, Quaternion.identity);
    }
}
