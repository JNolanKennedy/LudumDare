using UnityEngine;
using System.Collections;

public class LaserShip : BaseShip
{
	private int Charge;
    public GameObject Bullet;
    private bool Shooting;

	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
		this.Shield = 1;
		this.Speed = .01f;
		this.AttachPoint = new Vector2(0, 3);
		this.Charge = 0;
		this.source = this.GetComponent<AudioSource>();
        this.transform.Rotate(Vector3.forward * 180);
	}

	public override void Shoot()
	{
        if (!this.Shooting)
        {
            this.Shooting = true;
            GameObject clone = Instantiate(Bullet, this.transform.position+new Vector3(-18.5f,0), this.transform.rotation) as GameObject;
            BulletClass BI = clone.GetComponent(typeof(BulletClass)) as BulletClass;
            BI.OnShoot(transform.right, this.tag);
            this.Shooting = false;
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
