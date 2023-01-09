using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    [SerializeField] GameObject levelCompleteScreen;
    [SerializeField] Image honeyFill;
    // Start is called before the first frame update
    void Start()
    {
        levelManager.OnLevelComplete += LevelManager_OnLevelComplete;
        
        levelCompleteScreen.SetActive(false);
    }

    private void LevelManager_OnLevelComplete(object sender, LevelManager.OnLevelCompleteArgs e)
    {
        levelCompleteScreen.SetActive(true);
        float hp = (float) e.health;
        float maxHP = (float) e.maxHealth;
        float levelCount = (float) GameController.Instance.GetLevelCount(); 

        float honeyValue = (hp / maxHP) / levelCount;
        GameController.Instance.AddHoney(honeyValue);
        honeyFill.fillAmount = GameController.Instance.GetHoney();
    }
}
