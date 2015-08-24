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
        this.AttachPoint = new Vector3(-.4f,-.04f, -1);
		this.source = this.GetComponent<AudioSource>();
    }

    public override void Shoot()
    {
        ;
    }

	public override void overrideOnTriggerEnter2D(Collider2D coll)
	{

	}
}