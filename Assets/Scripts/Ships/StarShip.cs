using UnityEngine;
using System.Collections;

public class StarShip : BaseShip
{

    // Use this for initialization
    void Start()
    {
        this.HP = 3;
        this.Shield = 1;
        this.Speed = .05f;
        //this.Damage = 2;
        this.AttachPoint = new Vector2(0, 3);
		this.source = this.GetComponent<AudioSource>();
    }

    public override void Shoot()
    {
        ;
    }
}