using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager Instance; 
    [SerializeField] List<FlowerPair> flowerPairs;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one FlowerManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public FlowerPair GetFlowerPair(int index)
    {
        return flowerPairs[index];
    }

    public List<FlowerPair> GetFlowerPairList()
    {
        return flowerPairs;
    }

    public int GetMaxLength()
    {
        return flowerPairs.Count;
    }

}

[System.Serializable]
public struct FlowerPair
{
    public Sprite normalFlower;
    public Sprite wiltedFlower;
}