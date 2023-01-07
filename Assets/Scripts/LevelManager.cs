using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] CharacterController player;
    [SerializeField] SpawnPoint spawnPoint;
    [SerializeField] List<Collectable> collectables;
    [SerializeField] List<Objective> objectives;

    // Start is called before the first frame update
    void Start()
    {
        player.OnPlayerDead += Player_OnPlayerDead;
        spawnPoint.OnPlayerEnter += SpawnPoint_OnPlayerEnter;
    }

    private void Player_OnPlayerDead(object sender, EventArgs e)
    {
        spawnPoint.RespawnPlayer(player);
    }

    private void SpawnPoint_OnPlayerEnter(object sender, EventArgs e)
    {
        bool completedLevel = true;
        
        // Checks if each objective has been completed
        foreach (Objective objective in objectives)
        {
            if (objective.IsActive())
            {
                completedLevel = false;
                return;
            }
        }

        // Checks if there is the correct amount of honey stored
        completedLevel = spawnPoint.GetHoney() == objectives.Count;


        if (completedLevel)
        {
            Debug.Log("LevelManager.cs  Level Complete");
        }
    }
}
