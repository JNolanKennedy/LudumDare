using UnityEngine;
using System.Collections;

public class BaseSpawner : MonoBehaviour {
	public GameObject prefabSpawn;
	private bool endPass = false;
	float timer = 0.25f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (endPass == true & timer <= 0) {
			Instantiate (prefabSpawn, this.transform.position, this.transform.rotation);
			Destroy (gameObject);
		} else if (endPass == true)
			timer = timer - Time.deltaTime;
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall")
		{
			endPass = true;
		}
	}
	public void OnDrawGizmos()
	{
		if (prefabSpawn != null) {
			if (prefabSpawn.name == "basicship")
				Gizmos.DrawIcon (transform.position, "spawnbig.png", true);
		}
		else
			Gizmos.DrawIcon (transform.position, "spawnbig.png", true);
	}
}
