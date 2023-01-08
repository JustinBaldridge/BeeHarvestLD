using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Collision
{
    public event EventHandler OnPlayerEnter;

    int honey;

    public void RespawnPlayer(CharacterController player)
    {
        player.Reset();
        player.transform.position = transform.position;
    }

    protected override void CollisionEntry(CharacterController player)
    {  
        honey += player.CollectNectar(); 
        OnPlayerEnter?.Invoke(this, EventArgs.Empty);
    }

    protected override void CollisionExit(CharacterController player)
    {
        
    }

    public int GetHoney()
    {
        return honey;
    }
}
