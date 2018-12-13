using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripping : MonoBehaviour {

    // Editor: Syx
    private float cd;
    [SerializeField] private float timeFlag;
    [SerializeField] private StageObject _StageObject;
    [SerializeField] private GameObject drip;
    [SerializeField] private GameObject water;
    private void Start()
    {
        cd = _StageObject.cd;
    }

    void Update () {
		if(Time.time>timeFlag)
        {
            Instantiate(drip, water.transform.position, Quaternion.identity);
            timeFlag = Time.time + cd;
        }
	}
}
