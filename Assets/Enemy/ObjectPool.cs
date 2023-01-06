using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    
    [SerializeField] GameObject enemyPrefabSmall;
    [SerializeField] [Range(0, 50)] int poolSizeSmall = 7;
    
    [SerializeField] GameObject enemyPrefabChonky;
    [SerializeField] [Range(0, 50)] int poolSizeChonky= 2;
    
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;
    GameObject[] poolSmall;
    GameObject[] poolChonky;

    void Awake() 
    {
        PopulatePools();
    }

    void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }
    
    void PopulatePools()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }

        poolSmall = new GameObject[poolSizeSmall];

        for(int i = 0; i < poolSmall.Length; i++)
        {
            poolSmall[i] = Instantiate(enemyPrefabSmall, transform);
            poolSmall[i].SetActive(false);
        }

        poolChonky = new GameObject[poolSizeChonky];

        for(int i = 0; i < poolChonky.Length; i++)
        {
            poolChonky[i] = Instantiate(enemyPrefabChonky, transform);
            poolChonky[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }

        for(int i = 0; i < poolSmall.Length; i++)
        {
            if (poolSmall[i].activeInHierarchy == false)
            {
                poolSmall[i].SetActive(true);
                return;
            }
        }

        for(int i = 0; i < poolChonky.Length; i++)
        {
            if (poolChonky[i].activeInHierarchy == false)
            {
                poolChonky[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
