using UnityEngine;

public class WaterOrOil : MonoBehaviour {

    [SerializeField] private StageObject _StageObject;
    private bool IsWater;

    void Start() {
        IsWater = true;
        GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 1);
        GetComponent<SpriteRenderer>().material.SetFloat("_Speed", 5);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player" && IsWater) {
            _StageObject.GetPlayer().GetComponent<Player>().Die();
        }
        if (collision.name == "OilBucket") {
            IsWater = false;
            GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(1, 1, 0));
            GetComponent<SpriteRenderer>().material.SetFloat("_Speed", 2.5f);
            Destroy(collision.gameObject);
        }
    }

}
