using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int PlayerHP, ElecQuan;
    public bool RecvInput;
    //   [SerializeField] private StageObject _StageObject;
    public float proportion;
    public float cd; 
    [SerializeField] private KeyCode Left;
    [SerializeField] private KeyCode Right;
    [SerializeField] private KeyCode Jump;
    [SerializeField] private GameObject Bullet;
    
    public KeyCode Press;
    [SerializeField] private KeyCode Shoot;
    [SerializeField] private float Speed;
    private Animator _Animator;
    private Rigidbody2D _RigidBody2D;
    public bool Jumpable;

    void Start () {
        PlayerHP = 3;//血量
        ElecQuan = 0;//电量
        RecvInput = true;
        Jumpable = true;
        Time.timeScale = 1;
        _Animator = GetComponent<Animator>();
        _RigidBody2D = GetComponent<Rigidbody2D>();
	}
	//开关、充电、激光发射器各自分开写
	void Update () {
		if (RecvInput) {
            //Right
            if (Input.GetKeyDown(Right)) {
                _RigidBody2D.velocity = new Vector2(Speed, 0);
                _Animator.SetBool("Normal", false);
                _Animator.SetBool("WalktoRight", true);
            }
            if (Input.GetKeyUp(Right)) {
                _RigidBody2D.velocity = new Vector2(0, 0);
                _Animator.SetBool("WalktoRight", false);
                _Animator.SetBool("Normal", true);
            }
            //Left
            if (Input.GetKeyDown(Left)) {
                _RigidBody2D.velocity = new Vector2(-Speed, 0);
                _Animator.SetBool("Normal", false);
                _Animator.SetBool("WalktoLeft", true);
            }
            if (Input.GetKeyUp(Left)) {
                _RigidBody2D.velocity = new Vector2(0, 0);
                _Animator.SetBool("WalktoLeft", false);
                _Animator.SetBool("Normal", true);
            }
            //Jump
            if (Input.GetKeyDown(Jump) && Jumpable) {
                if (Physics2D.gravity.y <= 0) _RigidBody2D.velocity = new Vector2(0, 2);
                else _RigidBody2D.velocity = new Vector2(0, -2);
            }
            if(Input.GetKeyDown(Shoot))
            {
                Instantiate(Bullet, gameObject.transform.position,Quaternion.identity);
            }
        }
	}

    public void Charge() {
        RecvInput = false;
        GetComponent<Animator>().SetBool("Charge", true);
        //Add event "ChargeOver" in Animation
    }

    private void ChargeOver() {
        RecvInput = true;
        _Animator.SetBool("Charge", false);
        ElecQuan = 3;
    }

    //受伤
    public void Injure() {
        PlayerHP--;
        //_StageObject.HPPanel.Injure();
        if (PlayerHP == 0) Die();
    }

    public void Die() {
        RecvInput = false;
        _Animator.SetBool("Die", true);
        //Add event "DieOver" in Animation
    }

    public void DieOver() {
        Time.timeScale = 0;
  //      _StageObject.GameOverPanel.SetActive(true);
    }

}
