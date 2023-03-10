using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public Button returnToMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(Music.credits);
        returnToMenu.onClick.AddListener(ReturnToMenu);
    }

    private void ReturnToMenu()
    {
        SoundManager.Instance.PlaySound(Sound.buttonSFX);
        SceneManager.LoadScene(0);
    }
}
