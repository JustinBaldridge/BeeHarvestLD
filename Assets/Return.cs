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
        returnToMenu.onClick.AddListener(ReturnToMenu);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
