using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class MagnetMonster : MonoBehaviour {

    [SerializeField] private StageObject stageObject;
    [SerializeField] private float Radius;
    [SerializeField] private float ForceScale;
    private bool TakeEffect;

    public void Normal() {
        TakeEffect = false;
    }

    public void Effect() {
        TakeEffect = true;
    }

	void Update() {
        if (stageObject.ActivePlayer != null && TakeEffect)
            stageObject.MentalObject.Where(
                x => Vector2.Distance(x.transform.position, transform.position) < Radius
            ).ToList<GameObject>().ForEach(x => {
                Rigidbody2D r = x.GetComponent<Rigidbody2D>();
                Vector2 v = (Vector2)(transform.position - x.transform.position);
                r.AddForce(
                    ForceScale * v * x.GetComponent<Rigidbody2D>().mass / Mathf.Pow(v.magnitude, 2)
                );
            });
	}
}
