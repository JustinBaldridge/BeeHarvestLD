using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event EventHandler<OnLevelCompleteArgs> OnLevelComplete;

    [SerializeField] CharacterController player;
    [SerializeField] SpawnPoint spawnPoint;
    List<Collectable> collectables = new List<Collectable>();
    List<Objective> objectives = new List<Objective>();

    public class OnLevelCompleteArgs : EventArgs
    {
        public int health;
        public int maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        player.OnPlayerDead += Player_OnPlayerDead;
        spawnPoint.OnPlayerEnter += SpawnPoint_OnPlayerEnter;

        collectables = FindObjectsOfType<Collectable>().ToList();
        objectives = FindObjectsOfType<Objective>().ToList();
    }

    private void Player_OnPlayerDead(object sender, EventArgs e)
    {
        spawnPoint.RespawnPlayer(player);
        foreach (Collectable collectable in collectables)
        {
            collectable.Reset();
        }

        foreach (Objective objective in objectives)
        {
            objective.Reset();
        }
    }

    private void SpawnPoint_OnPlayerEnter(object sender, EventArgs e)
    {
        Debug.Log("LevelManager.cs  player enter");
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
        
        Debug.Log("LevelManager.cs  completed Level, objectives complete: " + completedLevel);
        // Checks if there is the correct amount of honey stored
        completedLevel = spawnPoint.GetHoney() == objectives.Count;
        
        Debug.Log("LevelManager.cs  completed Level, honey number: " + completedLevel + ", " + spawnPoint.GetHoney());

        if (completedLevel)
        {
            Debug.Log("LevelManager.cs  Level Complete");
            OnLevelComplete?.Invoke(this, new OnLevelCompleteArgs {
                health = player.GetHealth(),
                maxHealth = player.GetMaxHealth()
            });
        }
    }
}
