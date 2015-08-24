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
            Instantiate(prefabSpawn, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
		}
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
		Gizmos.DrawIcon (transform.position, "spawnbig.png", true);
	}
}
