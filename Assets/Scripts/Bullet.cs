using UnityEngine;
using System.Collections;
using System;

public class Bullet : BulletClass {

	private float Speed;
	private Vector2 Direction;

	// Use this for initialization
	public void Start () {
		this.source = this.GetComponent<AudioSource>();
		this.Damage = 1;
		this.Speed = 500f;
		this.source.PlayOneShot (shootSound, 1);
		this.GetComponent<Rigidbody2D>().AddForce(this.Direction * this.Speed);

	}

	public override void OnShoot(Vector2 direc, string shooter) {
		this.Direction = (Vector2)direc;
		this.Shooter = shooter;
		if (this.Shooter == "PlayerShip") {
			this.Foe = "Enemy";
		} else {
			this.Foe = "PlayerShip";
		}
	}

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (String.Equals(coll.gameObject.tag,this.Foe)) {
			ShipInterface enem = coll.gameObject.GetComponent (typeof(ShipInterface)) as ShipInterface;
			enem.TakeDamage (this.Damage);
			Destroy (this.gameObject);
		} else if (coll.gameObject.tag == "endwall") {
			Destroy (this.gameObject);
		}
    }
	// Update is called once per frame
	void Update () {

	}
}
