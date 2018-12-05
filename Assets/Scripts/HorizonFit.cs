using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizonFit : MonoBehaviour {

    [SerializeField] private bool IsOn;

    void Start () {
        if (IsOn) GetComponent<SpriteRenderer>().material.SetFloat("_PrivotX", transform.position.x);
	}
	
	void Update () {
		
	}
}
