using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Victory : MonoBehaviour
{
    float fillPercent;
    public float timeToWait;
    public Image honeyToFill;

    public TextMeshProUGUI percentText;
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(Music.victory);
        fillPercent = GameController.Instance.GetHoney();
        honeyToFill.fillAmount = fillPercent;
        percentText.text = ((fillPercent * 100) + "%");

        StartCoroutine(GameReset());
    }

    private IEnumerator GameReset()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(1);
    }
}
