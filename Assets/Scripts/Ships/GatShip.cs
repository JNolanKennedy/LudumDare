using UnityEngine;
using System.Collections;

public class GatShip : BaseShip {

    public GameObject Bullet;
    float cooldown = .15f;
	float overheat;

    public override void overrideStart()
    {
        this.HP = 3;
        this.Shield = 1;
        this.Speed = .1f;
        this.AttachPoint = new Vector3(-.6f, -.08f, -1);
        this.source = this.GetComponent<AudioSource>();
        this.transform.Rotate(Vector3.forward * 180);
		this.overheat = 0;
    }

	public override void overrideUpdate()
	{
	}

    public override void Shoot()
    {
		Debug.Log (overheat);
        if (overheat < .5f) {
			overheat += Time.deltaTime*2;
			cooldown = .15f;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            BaseBullet BI = clone.GetComponent(typeof(BaseBullet)) as BaseBullet;
            BI.OnShoot(transform.right, this.tag);
        }
		if (overheat >= .5f) {
			cooldown = 1f;
			overheat = 1f;
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
