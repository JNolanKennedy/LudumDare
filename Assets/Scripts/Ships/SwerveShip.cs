using UnityEngine;
using System.Collections;

public class SwerveShip : BaseShip {

    private bool Shooting;
    public GameObject Bullet;

    // Use this for initialization
    public override void overrideStart()
    {
        this.HP = 5;
        this.Shield = 5;
        this.Speed = .05f;
        this.AttachPoint = new Vector3(-.8f, -.05f, -1);
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
            BI.OnShoot(this.transform.right, this.tag);
            this.Shooting = false;
        }
    }

    public override void overrideOnTriggerEnter2D(Collider2D coll)
    {

    }
}
