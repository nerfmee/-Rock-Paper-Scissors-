using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] _prefabs;


    public void Spawn()
    {
        int RandomPrefab = Random.Range(0, _prefabs.Length);

        Instantiate(_prefabs[RandomPrefab],transform.position,transform.rotation);
    }

    private IEnumerator SpawnPerTime()
    {
        Spawn();
        yield return new WaitForSeconds(2);
        StartCoroutine(SpawnPerTime());
    }


    private void Start()
    {
        StartCoroutine(SpawnPerTime());
    }
}
