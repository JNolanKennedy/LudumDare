using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {
    public float fullHP;
    public float curHP;

	private BaseShip myShip;

    public void start()
    {

        this.myShip = this.GetComponentInParent((typeof(BaseShip))) as BaseShip;
		this.fullHP = this.myShip.getHP();
    }

	// Update is called once per frame
	void Update () {
		this.curHP = this.myShip.getHP ();
    	transform.localScale = new Vector3((curHP / fullHP), 1,1);
	}
}
