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
        Objective.OnAnyObjectiveCompleted += Objective_OnAnyObjectiveCompleted;
    }

    private void Player_OnPlayerDead(object sender, EventArgs e)
    {
        spawnPoint.RespawnPlayer(player);
    }

    private void Objective_OnAnyObjectiveCompleted(object sender, EventArgs e)
    {
        bool completedLevel = true;
        foreach (Objective objective in objectives)
        {
            if (objective.IsActive())
            {
                completedLevel = false;
                break;
            }
        }

        if (completedLevel)
        {
            Debug.Log("LevelManager.cs  Level Complete");
        }
    }
}
