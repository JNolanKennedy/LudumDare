using UnityEngine;
using System.Collections;

public class StarShip : BaseShip
{
    private bool Shooting;
    public GameObject Bullet;

    // Use this for initialization
	public override void overrideStart()
    {
        this.HP = 3;
        this.Shield = 1;
        this.Speed = .05f;
        //this.Damage = 2;
        this.AttachPoint = new Vector2(0, 3);
		this.source = this.GetComponent<AudioSource>();
    }

    public override void Shoot()
    {
        ;
    }

	public override void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy" && this.tag == "PlayerShip") {
			ShipInterface si = coll.gameObject.GetComponent(typeof(ShipInterface)) as ShipInterface;
			si.TakeDamage(1);
		}
	}
}