using UnityEngine;
using System.Collections;

public class ElectroShip : BaseShip 
{
	public GameObject Bullet;

    private GameObject player;
    private bool Shooting;

	// Use this for initialization
	public override void overrideStart() {
		this.HP = 3;
        this.Shield = 3;
        this.Speed = .1f;
		this.AttachPoint = new Vector3(-1, -.05f, -1);
        this.Shooting = false;
		this.source = this.GetComponent<AudioSource>();
        this.player = GameObject.Find("Player");
	}

	public override void Shoot() 
	{
        if (!this.Shooting)
        {
            this.Shooting = true;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            BulletClass BI = clone.GetComponent(typeof(BulletClass)) as BulletClass;
            BI.OnShoot(transform.right, this.tag);
            this.Shooting = false;
        }
	}

    public override bool TakeDamage(int val)
    {
        if (this.Shield <= 0)
        {
            this.Shield = 0;
            Speed = 0;
            if (this.HP > 0)
            {
                this.HP -= val;
            }
        }
        else
        {
            this.Shield -= val;
        }

        if (this.HP <= 0)
        {
            OnDeath();
            return true;
        }
        return false;
    }

	public override void overrideOnTriggerEnter2D(Collider2D coll)
	{

	}
}