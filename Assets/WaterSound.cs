using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySound(Sound.waterSFX);
    }
}
