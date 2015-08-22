using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, BulletInterface {

	private float Speed;
	private Vector2 Direction;

	// Use this for initialization
	void Start () {
		this.Speed = 500f;
		rb.AddForce(this.Direction*this.Speed);
	}

	public void OnShoot(Vector2 direc) {
		this.Direction = direc;
		Rigidbody rb = this.GetComponent(typeof(Rigidbody)) as Rigidbody;
		rb.AddForce(this.Direction*this.Speed);
	}
}
