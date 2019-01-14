using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool RecvInput;
    [SerializeField] private StageObject _StageObject;
    public bool Bright;
    [Header("向左移动的按键")][SerializeField] private KeyCode Left;
    [Header("向右移动的按键")][SerializeField] private KeyCode Right;
    [Header("跳的按键")][SerializeField] private KeyCode Jump;
    [Header("按下开关的键")]public KeyCode Press;
    [Header("发射子弹的键")][SerializeField] private KeyCode Shoot;
    [Header("移动速度的大小")][SerializeField] private float Speed;
    [Header("跳的速度的大小")][SerializeField] private float JumpSpeed;
    private Animator _Animator;
    private Rigidbody2D _RigidBody2D;
    private bool Jumpable;
    [HideInInspector] public bool FaceLeft;
    [SerializeField] private List<string> Param;

    void Start () {
        _Animator = GetComponent<Animator>();
        _RigidBody2D = GetComponent<Rigidbody2D>();
        FaceLeft = Jumpable = true;
        gameObject.name = "Player";
	}
	//开关、充电、激光发射器各自分开写
	void Update () {
        if (_StageObject.Dark != null && Bright)
            _StageObject.Dark.material.SetVector("_Center", new Vector4(transform.position.x, transform.position.y, transform.position.z));
		if (RecvInput) {
            //Right
            if (Input.GetKey(Right)) {
                Vector2 v = _RigidBody2D.velocity;
                v.x = Speed;
                _RigidBody2D.velocity = v;
                //_Animator.SetBool("Normal", false);
                _Animator.SetBool("RightStatic", true);
                FaceLeft = false;
            }
            if (Input.GetKeyUp(Right)) {
                Vector2 v = _RigidBody2D.velocity;
                v.x = 0;
                _RigidBody2D.velocity = v;
                //_Animator.SetBool("WalktoRight", false);
                //_Animator.SetBool("Normal", true);
            }
            //Left
            if (Input.GetKey(Left)) {
                Vector2 v = _RigidBody2D.velocity;
                v.x = -Speed;
                _RigidBody2D.velocity = v;
                //_Animator.SetBool("Normal", false);
                _Animator.SetBool("LeftStatic", true);
                FaceLeft = true;
            }
            if (Input.GetKeyUp(Left)) {
                Vector2 v = _RigidBody2D.velocity;
                v.x = 0;
                _RigidBody2D.velocity = v;
                //_Animator.SetBool("WalktoLeft", false);
                //_Animator.SetBool("Normal", true);
            }
            //Jump
            if (Input.GetKeyDown(Jump) && Jumpable) {
                Jumpable = false;
                float dy;
                if (Physics2D.gravity.y < 0) dy = JumpSpeed;
                else dy = -JumpSpeed;
                Vector2 v = _RigidBody2D.velocity;
                v.y = dy;
                _RigidBody2D.velocity = v;
            }
            //Shoot
            if (Input.GetKeyDown(Shoot)) {
                GameObject tmp = Instantiate(_StageObject.BulletPrefab, gameObject.transform.position, Quaternion.identity);
                tmp.GetComponent<Bullet>().sign = FaceLeft ? -1 : 1;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D c) {
        bool NowGravityPositive = Physics2D.gravity.y > 0;
        ContactPoint2D cp = c.GetContact(0);
        if (!NowGravityPositive && cp.normal.y > 0) Jumpable = true;
        if (NowGravityPositive && cp.normal.y < 0) Jumpable = true;
    }

    //受伤
    public void Injure() {
        _StageObject.PlayerHP--;
        _StageObject.HPPanel.Injure(_StageObject.PlayerHP);
        if (_StageObject.PlayerHP == 0) Die();
    }

    public void ChargeOver() {
        RecvInput = true;
        //gameObject.GetComponent<Animator>().SetBool("Charge", false);
        _StageObject.ElecQuan = 3;
    }

    public void win() {
        _StageObject.Win.SetActive(true);
        Time.timeScale = 0;
    }

    public void Die() {
        RecvInput = false;
        //_Animator.SetBool("Die", true);
        //Add event "DieOver" in Animation
        DieOver();
    }

    public void DieOver() {
        Destroy(gameObject);
        Time.timeScale = 0;
        _StageObject.Lose.SetActive(true);
    }

    public void CloseTransition() {
        foreach (string i in Param)
            _Animator.SetBool(i, false);
    }

}
