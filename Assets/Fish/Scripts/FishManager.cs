using System;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : ScriptableObject
{
    [SerializeField]
    static List<GameObject> fishes;
    public static List<FishController> spawnedFishes;
    public static void SpawnFish()
    {
        var fish = Instantiate(fishes[UnityEngine.Random.Range(0,fishes.Count)]);
        spawnedFishes.Add(fish.GetComponent<FishController>());
    }
}
