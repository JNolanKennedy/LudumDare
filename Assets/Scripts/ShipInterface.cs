using UnityEngine;
using System.Collections;

public interface ShipInterface
{
	void Shoot();
	void Move(Vector2 Direction);
	bool TakeDamage(int val);
	void OnDeath();
	void Upgrade();
	int getShields();
	void OnTriggerEnter2D(Collider2D coll);
	bool getIsParasite();
	int getHP();
    float getCooldown();

}