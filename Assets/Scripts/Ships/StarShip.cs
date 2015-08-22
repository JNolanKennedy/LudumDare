using UnityEngine;
using System.Collections;

public class StarShip : BaseShip
{
    //Hull Points
    private int HP;
    //Shield
    private int Shield;
    //Ship Speed
    private float Speed;
    //Damage the ship can do
    private int Damage;
    private bool Shooting;
    public GameObject Bullet;
    //Position on the ship the parastite shows up on (0,0) is upper left
    private Vector2 AttachPoint;

    // Use this for initialization
    void Start()
    {
        this.HP = 3;
        this.Shield = 1;
        this.Speed = .05f;
        //this.Damage = 2;
        this.AttachPoint = new Vector2(0, 3);
        this.Shooting = false;
    }

    public override void Shoot()
    {
        ;
    }
}