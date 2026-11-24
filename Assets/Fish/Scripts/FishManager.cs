using System;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> fishes;
    public List<FishController> spawnedFishes;
    void Start()
    {
        var fish = Instantiate(fishes[UnityEngine.Random.Range(0,fishes.Count)]);
        spawnedFishes.Add(fish.GetComponent<FishController>());
    }
}
