using UnityEngine;
using System.Collections;

public class GatShip : BaseShip {

    private bool Shooting;
    public GameObject Bullet;

    public override void overrideStart()
    {
        this.HP = 3;
        this.Shield = 2;
        this.Speed = .1f;
        this.AttachPoint = new Vector3(-.6f, -.08f, -1);
        this.Shooting = false;
        this.source = this.GetComponent<AudioSource>();
        this.transform.Rotate(Vector3.forward * 180);
    }

    public override void Shoot()
    {
        if (!this.Shooting)
        {
            this.Shooting = true;
            GameObject clone = Instantiate(Bullet, this.transform.position, this.transform.rotation) as GameObject;
            BaseBullet BI = clone.GetComponent(typeof(BaseBullet)) as BaseBullet;
            BI.OnShoot(transform.right, this.tag);
            this.Shooting = false;
        }
    }

    public override void overrideOnTriggerEnter2D(Collider2D coll)
    {

    }
}
