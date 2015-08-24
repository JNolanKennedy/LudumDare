using UnityEngine;
using System.Collections;

public class BasicShipAIV2 : AI {
	Transform player;
    float cooldown = 2f;
	float shotcooldown = .4f;

    // Update is called once per frame
    public override void overrideUpdate()
    {
		if (cooldown > 1) {
			AdjustPosition ();
		}
        if (cooldown < 1)
        {
			if (shotcooldown <= 0)
			{
				currentShip.Shoot();
				shotcooldown = .4f;
			}
			shotcooldown = shotcooldown - Time.deltaTime;
        }
		if (cooldown <= 0)
		{
			cooldown = 2f;
		}
        cooldown = cooldown - Time.deltaTime;

    }

    private void AdjustPosition()
    {
		player = GameObject.FindGameObjectWithTag ("PlayerShip").transform;
		currentShip.Move(new Vector2(-1f, 0));
		Vector3 dir = player.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public override float getCooldown()
    {
		return cooldown;
    }

    public void Infect()
    {
        //do nothing
    }
}
