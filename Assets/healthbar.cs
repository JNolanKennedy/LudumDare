using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {
    float fullHP;
    float curHP;

	private BaseShip myShip;

    public void start()
    {

		this.myShip = this.transform.parent.GetComponent<BaseShip> () as BaseShip;
		this.fullHP = this.myShip.getHP ();
    }

	// Update is called once per frame
	void Update () {
		this.curHP = this.myShip.getHP ();
    	transform.localScale = new Vector3((curHP / fullHP), 1,1);
	}
}
