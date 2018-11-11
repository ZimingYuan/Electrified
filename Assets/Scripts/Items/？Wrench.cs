using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour {

    // Editor: Syx
    [SerializeField] private KeyCode press;
    public Player Player;
    public StageObject gameManagee;
    [SerializeField] private string color;
    [SerializeField] private Sprite stateOne;
    [SerializeField] private Sprite stateTwo;
    [SerializeField] private GameObject gam;
    // Use this for initialization
    void Start () {
        press = Player.Press;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.RecvInput && Input.GetKeyDown(press))
        {
            if(gameObject.GetComponent<SpriteRenderer>().sprite==stateOne)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stateTwo;
                gam = gameManagee.GetDoorByColor(this.color);
                gam.GetComponent<Door>().OPEN();
            }
            if (gameObject.GetComponent<SpriteRenderer>().sprite == stateTwo)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stateOne;
                gam = gameManagee.GetDoorByColor(this.color);
                gam.GetComponent<Door>().CLOSE();
            }
        }
	}
}
