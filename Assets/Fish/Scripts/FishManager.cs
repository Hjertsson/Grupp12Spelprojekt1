using System;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    [Serializable]
    struct WeightedFish
    {
        public int weight;
        public GameObject fishPrefab;
    }
    [SerializeField]
    List<WeightedFish> fishes;
    public List<FishController> spawnedFishes;
    void Start()
    {
        List<GameObject> weightedList = new();
        foreach (var weightedFish in fishes)
        {
            for (int i = 0; i < weightedFish.weight; i++)
            {
                weightedList.Add(weightedFish.fishPrefab);   
            }
        }
        var fish = Instantiate(weightedList[UnityEngine.Random.Range(0,weightedList.Count)]);
        spawnedFishes.Add(fish.GetComponent<FishController>());
    }
}
