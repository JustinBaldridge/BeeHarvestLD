using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private int nectar;
    private int pollen;
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI nectarText;
    public TextMeshProUGUI pollenText;

    public CharacterController bee;
    
    // Start is called before the first frame update
    void Start()
    {
        bee = FindObjectOfType<CharacterController>();

        //GameController.Instance.GetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        nectar = bee.GetNectar();
        pollen = bee.GetPollen();

        nectarText.text = nectar.ToString();
        pollenText.text = pollen.ToString();
    }
}
