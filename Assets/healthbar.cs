using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {
    float fullHP;
    float curHP;

    public void start()
    {
        fullHP = (gameObject.GetComponentInParent((typeof(BaseShip))) as BaseShip).getHP();
        Debug.Log((gameObject.GetComponentInParent((typeof(BaseShip))) as BaseShip).name);
        Debug.Log(fullHP);
    }

	// Update is called once per frame
	void Update () {
        curHP = (gameObject.GetComponentInParent((typeof(BaseShip))) as BaseShip).getHP();
        transform.localScale = new Vector3((curHP / fullHP), 1,1);
	}
}
