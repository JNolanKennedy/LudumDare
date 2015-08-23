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
        if(fullShield == 0) {
            transform.localScale = new Vector3(0, 1, 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fullShield == 0)
        {
            transform.localScale = new Vector3(0, 1, 1);
        }
        else
        {
            curShield = myShip.getShields();
            transform.localScale = new Vector3((curShield / fullShield), 1, 1);
        }
    }
}
