using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLauncher : MonoBehaviour {

    // Editor: Yzm
    StageObject _StageObject;
    private bool TouchLaser;
    private Player player;
    [SerializeField] private Vector2 Direction;
    private RaycastHit2D[] Result = new RaycastHit2D[50];
    private List<Vector3> Points = new List<Vector3>();
    private GameObject Laser;

    void Start() {
        player = _StageObject.GetPlayer().GetComponent<Player>();
        Direction.Normalize();
        TouchLaser = false;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") TouchLaser = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") TouchLaser = false;
    }

    void Update() {
        if (player.RecvInput && Input.GetKeyDown(player.Press)) {
            LaserLaunch();
        }
    }

    public void LaserLaunch() {
        _StageObject.OpticalSw.GetComponent<OpticalSw>().Off();
        if (Laser != null) Destroy(Laser);
        //That means the number of mirrors should less than 50
        Collider2D tmpc = GetComponent<Collider2D>();
        Vector2 tmpd = Direction;
        Points.Clear(); Points.Add(transform.position);
        for (; ; ) {
            if (tmpc.Raycast(tmpd, Result) > 0) {
                Points.Add(Result[0].collider.gameObject.transform.position);
                if (Result[0].collider.name == "Map") break;
                //Name the Tilemap Map
                if (Result[0].collider.name == "OpticalSw") {
                    _StageObject.OpticalSw.GetComponent<OpticalSw>().On();
                    break;
                }
                tmpc = Result[0].collider;
                Vector2 nor = Result[0].collider.gameObject.GetComponent<Mirror>().Normal;
                tmpd = tmpd - 2 * Vector2.Dot(tmpd, nor) * nor;
                //Get the output direction through the input direction and the normal direction
            }
            else break;
        }
        Laser = Instantiate(_StageObject.LaserPrefab);
        Laser.GetComponent<LineRenderer>().SetPositions(Points.ToArray());
    }

}
