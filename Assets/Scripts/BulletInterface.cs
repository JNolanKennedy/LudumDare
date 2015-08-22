using UnityEngine;
using System.Collections;

public interface BulletInterface
{
	void OnShoot(Vector2 direc, string shooter);
	void OnTriggerEnter2D(Collider2D coll);
}
