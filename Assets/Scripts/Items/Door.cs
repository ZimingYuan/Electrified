using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    // Editor: Syx
    public string Color;//门的颜色
    public void OPEN()
    {
        //GetComponent<Animator>().SetBool("isPlay", true);
        gameObject.SetActive(false);
    }
    public void CLOSE()
    {
        //GetComponent<Animator>().SetBool("isPlay", false);
        gameObject.SetActive(true);
    }
}
