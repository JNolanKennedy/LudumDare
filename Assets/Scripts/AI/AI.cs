using UnityEngine;
using System.Collections;

public class AI: MonoBehaviour
{
	protected ShipInterface currentShip;
	protected bool pause = false;
	public void Start()
	{
		currentShip = this.GetComponent(typeof(ShipInterface)) as ShipInterface;
		registerSelf ();
		overrideStart ();
	}

	public virtual void overrideStart()
	{

	}

	public void Update()
	{
		if (!pause)
			overrideUpdate ();
	}

	public virtual void overrideUpdate()
	{

	}

	private void registerSelf()
	{

	}

	private void OnDestroy()
	{
		//deregs self
	}

	private void PauseHandler()
	{
		if (pause == false)
			pause = true;
		else
			pause = false;
	}
}