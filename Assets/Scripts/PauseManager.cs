using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour {
	bool pause = false;
	bool death = false;
	Rigidbody2D rbod;
	BoxCollider2D bcol;
	public List<GameObject> registeredObjects = new List<GameObject> ();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown("escape") && pause == false) || death == true && pause == false) {
			foreach (GameObject obj in registeredObjects) {
				if (obj == null)
				{
					//NOTHING
				}
				else
				{
					obj.BroadcastMessage("PauseHandler");
					rbod = obj.GetComponent<Rigidbody2D>();
					bcol = obj.GetComponent<BoxCollider2D>();

					if (rbod != null)
					{
						rbod.isKinematic = true;
					}

					if (bcol != null)
					{
						bcol.enabled = false;
					}

					pause = true;
				}

			}
		} 
		else if(Input.GetKeyDown("escape") && death != true)
		{
			foreach (GameObject obj in registeredObjects) {
				if (obj == null)
				{
					//nothing
				}
				else
				{
					rbod = obj.GetComponent<Rigidbody2D>();
					bcol = obj.GetComponent<BoxCollider2D>();

					if (rbod != null)
					{
						rbod.isKinematic = false;
					}
					
					if (bcol != null)
					{
						bcol.enabled = true;
					}

					pause = false;
					obj.BroadcastMessage("PauseHandler", 0);
				}
			}
		}

		registeredObjects.RemoveAll (GameObject => GameObject == null);
	
	}
		
	public void registerObject(GameObject obj)
	{
		this.registeredObjects.Add (obj);
	}
	public void deregisterObject(GameObject obj)
	{
		this.registeredObjects.Remove (obj);
	}
	public void gameOver()
	{
		death = true;
	}

}
