using UnityEngine;
using System.Collections;

public class FastShipAI : AI {
    Transform player;
    float cooldownTotal = .3f;
    float cooldown = .3f;

	// Use this for initialization
	public override void overrideStart () {
		this.transform.Rotate (Vector3.forward * 180);
        cooldownTotal = cooldown;
	}
	
	// Update is called once per frame
	public override void overrideUpdate()
	{
		player = GameObject.FindGameObjectWithTag ("PlayerShip").transform;
        AdjustPosition();
        if(cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = .3f;
        }
        cooldown = cooldown - Time.deltaTime; 
	}

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public override float getCooldown()
    {
        return cooldownTotal;
    }
    public void Infect()
    {
        //do nothing
    }
}
