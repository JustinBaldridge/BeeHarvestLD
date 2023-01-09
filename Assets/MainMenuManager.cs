using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public Button loadGame;
    public Button exitApplication;
    public Button credits;
    public Button options;
    public Sprite[] buttonImages;
    public Sprite[] wiltedImages;
    public TextMeshProUGUI optionsUNAVAILABLE;

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
        SoundManager.Instance.PlaySound(Sound.buttonSFX);
        SceneManager.LoadScene(gameScene);
    }

    private void Exit()
    {
        SoundManager.Instance.PlaySound(Sound.buttonSFX);
        Application.Quit();
    }

    private void Credits()
    {
        SoundManager.Instance.PlaySound(Sound.buttonSFX);
        SceneManager.LoadScene(1);
    }

    private void Options()
    {
        SoundManager.Instance.PlaySound(Sound.buttonSFX);
        int length = buttonImages.Length;
        Sprite sprite = options.GetComponent<Image>().sprite;
        for(int i = 0; i < length; i++)
        {
            if(sprite == buttonImages[i])
            {
                options.GetComponent<Image>().sprite = wiltedImages[i];
            }
            else
            {

            }
        }

        optionsUNAVAILABLE.text = "NOT YET\n:p";
    }
}
