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
    float finalTime;

    public TextMeshProUGUI percentText;
    public TextMeshProUGUI timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic(Music.victory);
        finalTime = GameController.Instance.GetFinalTime();
        fillPercent = GameController.Instance.GetHoney();
        honeyToFill.fillAmount = fillPercent;
        percentText.text = (Mathf.Round((fillPercent * 100)) + "%");
        timeText.text = (finalTime.ToString());

        StartCoroutine(GameReset());
    }

    private IEnumerator GameReset()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(1);
    }
}
