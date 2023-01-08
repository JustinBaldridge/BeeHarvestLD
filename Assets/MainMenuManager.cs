using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button loadGame;
    public Button exitApplication;
    public Button credits;
    public Button options;
    public Sprite[] buttonImages;

    public string gameScene;

    // Start is called before the first frame update
    void Start()
    {
        loadGame.onClick.AddListener(LoadGame);
        exitApplication.onClick.AddListener(Exit);
        credits.onClick.AddListener(Credits);
        options.onClick.AddListener(Options);

        loadGame.GetComponent<Image>().sprite = buttonImages[Random.Range(0, 4)];
        exitApplication.GetComponent<Image>().sprite = buttonImages[Random.Range(0, 4)];
        credits.GetComponent<Image>().sprite = buttonImages[Random.Range(0, 4)];
        options.GetComponent<Image>().sprite = buttonImages[Random.Range(0, 4)];
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Credits()
    {

    }

    private void Options()
    {

    }
}
