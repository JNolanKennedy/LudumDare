using UnityEngine;
using System.Collections;

public class LaserShip : BaseShip
{
	// Use this for initialization
	void Start () {
		this.HP = 3;
		this.Shield = 0;
		this.Speed = .01f;
		this.AttachPoint = new Vector2(0, 3);
		this.Charge = 0;
		this.source = this.GetComponent<AudioSource>();
	}
}
