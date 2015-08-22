using UnityEngine;
using System.Collections;

public interface BehaviorInterface
{
	void Shoot();
	void Move(int Direction);
	bool TakeDamage();
	void OnDeath();
	void Infect();
	void Upgrade();
}