using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class MagnetMonster : MonoBehaviour {

    [SerializeField] private StageObject stageObject;
    [SerializeField] private float Radius;
    [SerializeField] private Vector2 Force;
    private bool TakeEffect;

    public void Normal() {
        TakeEffect = false;
    }

    public void Effect() {
        TakeEffect = true;
    }

	void Update() {
        if (TakeEffect)
            stageObject.MentalObject.Where(
                x => Vector2.Distance(x.transform.position, transform.position) < Radius
            ).ToList<GameObject>().ForEach(
                x => x.GetComponent<Rigidbody2D>().AddForce(Force)
            );
	}
}
