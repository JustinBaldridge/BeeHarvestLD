using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance; 

    [SerializeField] List<string> levels;

    int currentLevel = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one GameController! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadLevel(currentLevel));
        }
    }

    void Initialize()
    {
        LevelManager currentLevel = FindObjectOfType<LevelManager>();   
        
        currentLevel.OnLevelComplete += LevelManager_OnLevelComplete;
    }

    void LevelManager_OnLevelComplete(object sender, EventArgs e)
    {
        currentLevel++;

        StartCoroutine(LoadLevel(currentLevel));
    }

    IEnumerator LoadLevel(int index)
    {
        yield return new WaitForSeconds(1.5f);

        // Game Complete
        if (currentLevel >= levels.Count)
        {
            yield break;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levels[currentLevel]);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Initialize();
    }


}
