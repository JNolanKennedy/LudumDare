using UnityEngine;
using System.Collections;

public class shieldbar : MonoBehaviour {

    public float fullShield;
    public float curShield;
	public BaseShip myShip;

    public void Start()
    {
        myShip = this.GetComponentInParent((typeof(BaseShip))) as BaseShip;
        fullShield = myShip.getShields();
    }

    // Update is called once per frame
    void Update()
    {
        curShield = myShip.getShields();
        transform.localScale = new Vector3((curShield / fullShield), 1, 1);
    }
}
