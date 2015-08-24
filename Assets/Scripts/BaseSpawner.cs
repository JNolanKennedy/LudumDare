using UnityEngine;
using System.Collections;

public class BaseSpawner : MonoBehaviour {
	public GameObject prefabSpawn;
	public float spawntime = 1f;
	private bool endPass = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (endPass == true) {
			spawntime -= Time.deltaTime;

			if (spawntime <= 0)
			{
				Instantiate (prefabSpawn,this.transform.position,this.transform.rotation);
				Destroy(this.gameObject);
			}
		}
	
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "endwall")
		{
			endPass = true;
		}
	}
}
