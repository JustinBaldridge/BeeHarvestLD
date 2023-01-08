using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collision
{
    protected override void CollisionEntry(CharacterController player)
    {
        player.AddPickup();           
    }

    protected override void CollisionExit(CharacterController player)
    {
        
    }
}
