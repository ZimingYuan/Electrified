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
    private LineRenderer Laser;
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

    public void LaserLaunch() {
        _StageObject.OpticalSw.GetComponent<OpticalSw>().Off();
        if (Laser != null) Destroy(Laser.gameObject);
        Collider2D tmpc = GetComponent<Collider2D>();
        Vector2 tmpd = Direction;
        Points.Clear(); Points.Add(transform.position);
        for (; ; ) {
            if (tmpc.Raycast(tmpd, Result) > 0) {
                Points.Add(Result[0].point);
                if (Result[0].collider.name.StartsWith("Mirror")) {
                    tmpc = Result[0].collider;
                    Vector2 nor = Result[0].collider.gameObject.GetComponent<Mirror>().Normal;
                    tmpd = tmpd - 2 * Vector2.Dot(tmpd, nor) * nor;
                }
                else if (Result[0].collider.name == "OpticalSw") {
                    _StageObject.OpticalSw.GetComponent<OpticalSw>().On();
                    break;
                }
                else break;
            }
            else break;
        }
        Laser = Instantiate(_StageObject.LaserPrefab).GetComponent<LineRenderer>();
        Laser.positionCount = Points.Count;
        Laser.SetPositions(Points.ToArray());
    }

}
