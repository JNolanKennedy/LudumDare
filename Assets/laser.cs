using UnityEngine;
using System.Collections;
using System;

public class laser : BulletClass {

    private float Speed;
    private float time;
    private Vector3 Direction;

    // Use this for initialization
    public void Start()
    {
        this.source = this.GetComponent<AudioSource>();
        this.Damage = 1;
        this.Speed = .01f;
        time = 3;
        this.source.PlayOneShot(shootSound, 1);
    }

    public override void OnShoot(Vector2 direc, string shooter)
    {
        Direction = direc;
        this.Shooter = shooter;
        if (this.Shooter == "PlayerShip")
        {
            this.Foe = "Enemy";
        }
        else
        {
            this.Foe = "PlayerShip";
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (String.Equals(coll.gameObject.tag, this.Foe))
        {
            ShipInterface enem = coll.gameObject.GetComponent(typeof(ShipInterface)) as ShipInterface;
            enem.TakeDamage(this.Damage);
        }
    }

    //aadaf
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 0)
        {
            this.transform.position += (float)this.Speed * (Vector3)Direction;
        }
        else
        {
            Destroy(gameObject);
            this.transform.position += (float)this.Speed * (Vector3)Direction;
        }
    }
}
