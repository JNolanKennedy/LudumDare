using UnityEngine;
using System.Collections;

public class LaserShipAI : AI {

    float cooldownTotal = 3.6f;
    float cooldown = 3.6f;

    // Update is called once per frame
	public override void overrideUpdate()
    {
        AdjustPosition();
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = 3.6f;
        }
        cooldown = cooldown - Time.deltaTime;
    }

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, 0));
    }

    public float getCoolDown()
    {
        return cooldownTotal;
    }

    public void Infect()
    {
        //do nothing
    }
}
