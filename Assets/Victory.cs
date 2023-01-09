using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    float fillPercent;
    public Image honeyToFill;
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(Music.victory);
        fillPercent = GameController.Instance.GetHoney();
        honeyToFill.fillAmount = fillPercent;

        StartCoroutine(GameReset());
    }

    private IEnumerator GameReset()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);
    }
}
