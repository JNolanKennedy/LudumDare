using UnityEngine;
using System.Collections;

public class shieldbar : MonoBehaviour {

    float fullShield;
    float curShield;

    public void start()
    {
        fullShield = (gameObject.GetComponentInParent((typeof(BaseShip))) as BaseShip).getShields();
    }

    // Update is called once per frame
    void Update()
    {
		if (fullShield > 0) {
			curShield = (gameObject.GetComponentInParent ((typeof(BaseShip))) as BaseShip).getShields ();
			transform.localScale = new Vector3 ((curShield / fullShield), 1, 1);
		}
    }
}
