using UnityEngine;
using System.Collections;

public interface BulletInterface
{
	void OnShoot(Vector2 direc);
	void OnCollisionEnter2D(Collision2D coll);
}
