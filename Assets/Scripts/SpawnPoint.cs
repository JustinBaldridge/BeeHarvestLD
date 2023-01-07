using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void RespawnPlayer(CharacterController player)
    {
        player.transform.position = transform.position;
        player.Reset();
    }
}
