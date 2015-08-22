using UnityEngine;
using System.Collections;

public class FastShipAI : MonoBehaviour, AI {
    BehaviorInterface currentShip;
    bool isPlayer = false;
    Transform player;
    float cooldown = .3f;

	// Use this for initialization
	void Start () {
        currentShip = this.GetComponent(typeof(BehaviorInterface)) as BehaviorInterface;
        if (this.transform.parent != null)
        {
            isPlayer = true;
        }
        else
        {
            this.transform.Rotate(Vector3.forward * 180);
            player = GameObject.Find("Player").transform.GetChild(0);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayer == false)
        {
            AdjustPosition();
            if(cooldown <= 0)
            {
                currentShip.Shoot();
                cooldown = .3f;
            }
            cooldown = cooldown - Time.deltaTime;
            
        }   
	}

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Infect()
    {
        //do nothing
    }
}
