using UnityEngine;
using System.Collections;

public class FastShip : BaseShip
{
	private bool Shooting;
	public GameObject Bullet;
    float cooldown = .3f;
	
	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
		this.Shield = 0;
		this.Speed = .2f;
		this.AttachPoint = new Vector3(-.4f, -.05f, -1);
		this.Shooting = false;
		this.source = this.GetComponent<AudioSource>();
	}
	
	public override void Shoot()
	{
		if (!this.Shooting) {
			this.Shooting = true;
			GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
			BaseBullet BI = clone.GetComponent (typeof(BaseBullet)) as BaseBullet;
			BI.OnShoot(transform.right, this.tag);
			this.Shooting = false;
		}
	}

    public override float getCooldown()
    {
        return cooldown;
    }
	public override void overrideOnTriggerEnter2D(Collider2D coll)
	{

	}
}

