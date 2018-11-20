using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPanel : MonoBehaviour {
	
	public void Injure(int num) {
        SpriteRenderer Heart = transform.Find("Heart" + num).gameObject.GetComponent<SpriteRenderer>();
        Heart.sprite = Resources.Load<Sprite>("NoHeart");
    }

}
