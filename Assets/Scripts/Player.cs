using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int PlayerHP, ElecQuan, BatteryNum;
    public bool RecvInput;
    [SerializeField] private StageObject _StageObject;
    [SerializeField] private KeyCode Left;
    [SerializeField] private KeyCode Right;
    [SerializeField] private KeyCode Jump;
    public KeyCode Press;
    [SerializeField] private KeyCode Shoot;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpDuration;
    [SerializeField] private Vector2 JumpSpeed;
    //private Animator _Animator;
    private Rigidbody2D _RigidBody2D;
    public bool FaceLeft;
    public float cd, proportion;
    private float timecd;

    void Start () {
        PlayerHP = 3;//血量
        ElecQuan = BatteryNum = 0;//电量
        timecd = 0;
        RecvInput = true;
        Time.timeScale = 1;
        //_Animator = GetComponent<Animator>();
        _RigidBody2D = GetComponent<Rigidbody2D>();
        FaceLeft = true;
        gameObject.name = "Player";
	}
	//开关、充电、激光发射器各自分开写
	void Update () {
		if (RecvInput) {
            //Right
            if (Input.GetKeyDown(Right)) {
                _RigidBody2D.velocity = new Vector2(Speed, 0);
                //_Animator.SetBool("Normal", false);
                //_Animator.SetBool("WalktoRight", true);
                FaceLeft = false;
            }
            if (Input.GetKeyUp(Right)) {
                _RigidBody2D.velocity = new Vector2(0, 0);
                //_Animator.SetBool("WalktoRight", false);
                //_Animator.SetBool("Normal", true);
            }
            //Left
            if (Input.GetKeyDown(Left)) {
                _RigidBody2D.velocity = new Vector2(-Speed, 0);
                //_Animator.SetBool("Normal", false);
                //_Animator.SetBool("WalktoLeft", true);
                FaceLeft = true;
            }
            if (Input.GetKeyUp(Left)) {
                _RigidBody2D.velocity = new Vector2(0, 0);
                //_Animator.SetBool("WalktoLeft", false);
                //_Animator.SetBool("Normal", true);
            }
            //Jump
            if (Input.GetKeyDown(Jump) && Time.time>timecd) {
                if (Physics2D.gravity.y <= 0) _RigidBody2D.velocity = JumpSpeed;
                else _RigidBody2D.velocity = -JumpSpeed;
                timecd = Time.time + JumpDuration;
            }
            //Shoot
            if (Input.GetKeyDown(Shoot)) {
                GameObject tmp = Instantiate(_StageObject.BulletPrefab, gameObject.transform.position, Quaternion.identity);
                tmp.GetComponent<Bullet>().sign = FaceLeft ? -1 : 1;
            }
        }
	}

    //受伤
    public void Injure() {
        PlayerHP--;
        //_StageObject.HPPanel.Injure();
        if (PlayerHP == 0) Die();
    }

    public void ChargeOver() {
        RecvInput = true;
        //gameObject.GetComponent<Animator>().SetBool("Charge", false);
        ElecQuan = 3;
    }

    public void Die() {
        RecvInput = false;
        //_Animator.SetBool("Die", true);
        //Add event "DieOver" in Animation
    }

    public void DieOver() {
        Time.timeScale = 0;
  //      _StageObject.GameOverPanel.SetActive(true);
    }

}
