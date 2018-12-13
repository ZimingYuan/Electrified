using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPanel : MonoBehaviour {
	
	public void Injure(int num) {
        SpriteRenderer Heart = transform.Find("Heart" + num).gameObject.GetComponent<SpriteRenderer>();
        Heart.color = new Color(0, 0, 0, 0);
    }

}
