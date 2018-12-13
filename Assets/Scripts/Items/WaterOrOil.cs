using UnityEngine;

public class WaterOrOil : MonoBehaviour {

    // Editor: Yzm
    private bool IsWater;
    [SerializeField] private StageObject _StageObject;

    void Start() {
        IsWater = true;
        GetComponent<SpriteRenderer>().material.SetFloat("_IsWater", 1);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player" && IsWater) {
            Player player = collision.gameObject.GetComponent<Player>();
            int hp = _StageObject.PlayerHP;
            for (int i = 1; i <= hp; i++) player.Injure();
        }
        if (collision.name == "OilBucket") {
            IsWater = false;
            GetComponent<SpriteRenderer>().material.SetFloat("_IsWater", 0);
            Destroy(collision.gameObject);
        }
    }

}
