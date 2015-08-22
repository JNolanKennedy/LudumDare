using UnityEngine;
using System.Collections;

public interface BehaviorInterface
{
	void Shoot();
	void Move(Vector2 Direction);
	bool TakeDamage(int val);
	void OnDeath();
	void Infect();
	void Upgrade();
}