using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : EnemyController
{
    public void FireBeam()
    {
        realTrigger.Fire(transform.position, player.transform.position);
    }

    public void Update()
    {
        if (player)
            FireBeam();
    }
}
