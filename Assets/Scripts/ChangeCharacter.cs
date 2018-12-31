using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour {

    private Player play;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject Magnet;
    [SerializeField] private StageObject _StageObject;
    public bool itrue ;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(_StageObject.GetPlayer().GetComponent<Player>().Press)&&itrue==true)
        {
            play = collision.gameObject.GetComponent<Player>();
            play.RecvInput = false;
            play.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            play.Bright = false;
            itrue = false;
            Magnet.GetComponent<ChangeCharacter>().itrue = true;
            player2.GetComponent<Player>().Bright = true;
            player2.GetComponent<Player>().RecvInput = true;
            _StageObject.ActivePlayer = player2;
        }
    }
}
