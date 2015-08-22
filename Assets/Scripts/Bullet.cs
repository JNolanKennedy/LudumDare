using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour, BulletInterface {

	private float Speed;
	private Vector2 Direction;
	private bool Going;

	// Use this for initialization
	void Start () {
		this.Speed = .2f;
		this.Going = false;
	}

	public void OnShoot(Vector2 direc) {
		this.Direction = direc;
		this.Going = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("I GOT TO HERE");
		//If it collides with something should deal damage and die...
		if (this.Going) {
			this.transform.position += this.Speed * (Vector3)this.Direction;
		}
	}
}
