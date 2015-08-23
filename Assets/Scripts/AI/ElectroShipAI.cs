using UnityEngine;
using System.Collections;

public class ElectroShipAI : AI
{
    Transform player;
    float cooldown = .6f;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShip").transform;
        AdjustPosition();
        if (cooldown <= 0)
        {
            currentShip.Shoot();
            cooldown = .6f;
        }
        cooldown = cooldown - Time.deltaTime;
    }

    private void AdjustPosition()
    {
        float dist = gameObject.transform.position.x - player.position.x;
        if (dist > 10)
        {
            currentShip.Move(new Vector2(-1f, 0));
        }
        else if (dist < 8)
        {
            currentShip.Move(new Vector2(1f, 0));
        }
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Infect()
    {
        //do nothing
    }
}
