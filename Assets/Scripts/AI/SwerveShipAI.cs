using UnityEngine;
using System.Collections;

public class SwerveShipAI : AI {

    float cooldown = .3f;
    float move = 1.5f;

    // Update is called once per frame
    public override void overrideUpdate()
    {
        AdjustPosition();
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = .3f;
        }
        cooldown = cooldown - Time.deltaTime;
    }

    private void AdjustPosition()
    {
        currentShip.Move(new Vector2(-1f, move));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "boundwall1" || collision.name == "boundwall3")
        {
            move = move * -1;
        }
    }
    public void Infect()
    {
        //do nothing
    }
}
