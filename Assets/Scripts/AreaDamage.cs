using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : Collision
{
    protected override void CollisionEntry(CharacterController player)
    {
        player.SetDamageTimer(true);
        active = true;
    }

    protected override void CollisionExit(CharacterController player)
    {
        player.SetDamageTimer(false);
        active = true;
    }
}
