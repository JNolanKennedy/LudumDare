using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, BulletInterface {

	private float Speed;
	private Vector2 Direction;
	private bool Going;

	// Use this for initialization
	void Start () {
		this.Speed = 500f;
        this.GetComponent<Rigidbody>().AddForce(this.transform.right * this.Speed);
	}

	public void OnShoot(Vector2 direc) {
		this.Direction = direc;
		this.Going = true;
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        ;
    }
	// Update is called once per frame
	void Update () {
	}
}
