using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLauncher : MonoBehaviour {

    // Editor: Yzm
    [SerializeField] private StageObject _StageObject;
    private bool TouchLaser, IsOn;
    private Player player;
    [SerializeField] private Vector2 Direction;
    [SerializeField] private float LaunchDuration;
    private RaycastHit2D[] Result = new RaycastHit2D[50];
    private List<Vector3> Points = new List<Vector3>();
    private List<LineRenderer> Laser = new List<LineRenderer>();
    private float NowTime;

    void Start() {
        player = _StageObject.GetPlayer().GetComponent<Player>();
        Direction.Normalize();
        TouchLaser = false; IsOn = true;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") TouchLaser = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") TouchLaser = false;
    }

    void Update() {
        if (TouchLaser && player.RecvInput && Input.GetKeyDown(player.Press)) { IsOn = !IsOn; }
        if (NowTime > LaunchDuration) { NowTime = 0; if (IsOn) LaserLaunch(); }
        else NowTime += Time.deltaTime;
    }

    private Vector3 Backward(Vector3 p) {
        return new Vector3(p.x, p.y, p.z + 1);
    }

    public void LaserLaunch() {
        _StageObject.OpticalSw.GetComponent<OpticalSw>().Off();
        foreach (LineRenderer i in Laser) Destroy(i.gameObject); Laser.Clear();
        Collider2D tmpc = GetComponent<Collider2D>();
        Vector2 tmpd = Direction;
        Points.Clear(); Points.Add(Backward(transform.position));
        for (; ; ) {
            if (tmpc.Raycast(tmpd, Result) > 0) {
                if (Result[0].collider.name == "Player") Result[0] = Result[1];
                Points.Add(Backward(Result[0].point) + 0.15f * new Vector3(tmpd.x, tmpd.y));
                if (Result[0].collider.name.StartsWith("Mirror")) {
                    tmpc = Result[0].collider;
                    Vector2 nor = Result[0].normal;
                    tmpd = Vector2.Reflect(tmpd, nor);
                }
                else if (Result[0].collider.name == "OpticalSw") {
                    _StageObject.OpticalSw.GetComponent<OpticalSw>().On();
                    break;
                }
                else break;
            }
            else break;
        }
        for (int i = 0; i < Points.Count - 1; i++) {
            LineRenderer tmp = Instantiate(_StageObject.LaserPrefab).GetComponent<LineRenderer>();
            tmp.positionCount = 2;
            for (int j = 0; j < 2; j++) tmp.SetPosition(j, Points[i + j]);
            Laser.Add(tmp);
        }
    }

}
