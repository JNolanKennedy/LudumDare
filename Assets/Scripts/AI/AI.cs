using UnityEngine;
using System.Collections;

public class AI: MonoBehaviour
{
	protected ShipInterface currentShip;
	public void Start()
	{
		currentShip = this.GetComponent(typeof(ShipInterface)) as ShipInterface;
		registerSelf ();
		overrideStart ();
	}

	public virtual void overrideStart()
	{

	}

	private void registerSelf()
	{

	}

	private void OnDestroy()
	{
		//deregs self
	}
}