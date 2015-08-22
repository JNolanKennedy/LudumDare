﻿using UnityEngine;
using System.Collections;
using System;

public class Electroball : MonoBehaviour, BulletInterface
{

    public AudioClip shootSound;

    private float Speed;
    private Vector2 Direction;
    private int Damage;
    private AudioSource source;
    private string Shooter;
    private string Foe;

    // Use this for initialization
    void Start()
    {
        this.source = this.GetComponent<AudioSource>();
        this.Damage = 1;
        this.Speed = 300f;
        this.source.PlayOneShot(shootSound, 1);
        this.GetComponent<Rigidbody2D>().AddForce(this.Direction * this.Speed);

    }

    public void OnShoot(Vector2 direc, string shooter)
    {
        this.Direction = direc;
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
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "endwall")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}