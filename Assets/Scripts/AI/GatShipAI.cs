using UnityEngine;
using System.Collections;

public class GatShipAI : AI {
    float cooldown = .15f;
    float cooldownTotal = .15f;

    public override void overrideUpdate()
    {
        currentShip.Move(new Vector2(-1f, 0));
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = .15f;
        }
        cooldown = cooldown - Time.deltaTime;
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
