using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] _prefabs;
    float time = 4;
    private MovePrefab _movePrefab;
    private int RandomPrefab = 0;

    public void Spawn()
    {
        RandomPrefab = Random.Range(0, _prefabs.Length);
        Instantiate(_prefabs[RandomPrefab],transform.position,transform.rotation);
        if (time <= 0.5f)
        {
            time = 0.5f;
        }
        else
        {
            time -= 0.15f;
        }
    }

    private IEnumerator SpawnPerTime()
    {
        Spawn();
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnPerTime());
    }



    private void Start()
    {
        StartCoroutine(SpawnPerTime());;
    }
}
