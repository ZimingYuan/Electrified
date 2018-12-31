using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripping : MonoBehaviour {

    // Editor: Syx
    [SerializeField] private float cd;
    private float timeFlag;
    [SerializeField] private StageObject _StageObject;
    [SerializeField] private GameObject drip;
    [SerializeField] private GameObject water;

    void Update () {
		if(Time.time>timeFlag)
        {
            Instantiate(drip, water.transform.position, Quaternion.identity);
            timeFlag = Time.time + cd;
        }
	}
}
