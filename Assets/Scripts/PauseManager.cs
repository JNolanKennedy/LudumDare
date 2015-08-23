using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour {
	bool pause = false;
	Rigidbody2D rbod;
	BoxCollider2D bcol;
	public List<GameObject> registeredObjects = new List<GameObject> ();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape") && pause == false) {
			foreach (GameObject obj in registeredObjects) {
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
		else if(Input.GetKeyDown("escape"))
		{
			foreach (GameObject obj in registeredObjects) {
				obj.BroadcastMessage("PauseHandler", 0);
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
			}
		}
	
	}
		
	public void registerObject(GameObject obj)
	{
		this.registeredObjects.Add (obj);
	}
	public void deregisterObject(GameObject obj)
	{
		this.registeredObjects.Remove (obj);
	}

}
