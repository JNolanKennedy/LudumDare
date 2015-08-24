using UnityEngine;
using System.Collections;

public class StarShipAI : AI {

    Transform player;

    // Update is called once per frame
	public override void overrideUpdate()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShip").transform;
        AdjustPosition();
    }

    private void AdjustPosition()
    {
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        currentShip.Move(transform.right);
    }
}
