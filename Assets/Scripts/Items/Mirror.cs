using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    public Vector2 Normal;
    private bool TouchMirror;
    private bool OnPress;
    [SerializeField] private KeyCode Press;
    [SerializeField] private float RotateSpeed;
    [SerializeField] private StageObject _StageObject;

    void Start() {
        Normal.Normalize();
        TouchMirror = true;
        OnPress = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") TouchMirror = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") TouchMirror = false;
    }

    void Update() {
        if (Input.GetKeyDown(Press)) OnPress = true;
        if (Input.GetKeyUp(Press)) {
            OnPress = false;
            _StageObject.LaserLauncher.GetComponent<LaserLauncher>().LaserLaunch();
        }
        if (OnPress) {
            transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
            float Angle = Mathf.Deg2Rad * (Vector2.Angle(Vector2.right, Normal) + RotateSpeed * Time.deltaTime);
            Normal = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
        }
    }

}
