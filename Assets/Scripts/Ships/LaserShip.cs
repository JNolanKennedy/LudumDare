using UnityEngine;
using System.Collections;

public class LaserShip : BaseShip
{
	private int Charge;

	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
		this.Shield = 1;
		this.Speed = .01f;
		this.AttachPoint = new Vector2(0, 3);
		this.Charge = 0;
		this.source = this.GetComponent<AudioSource>();
	}

	public override void Shoot()
	{
		this.Charge += (int)Time.deltaTime;
		if (this.Charge >= 2) {
			this.Charge = 0;
		}
	}

	public override void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy" && this.tag == "PlayerShip") {
			ShipInterface si = coll.gameObject.GetComponent(typeof(ShipInterface)) as ShipInterface;
			si.TakeDamage(1);
		}
	}
}
