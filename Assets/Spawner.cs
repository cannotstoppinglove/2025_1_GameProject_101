using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MisslePrefabs;

    [Header("���� Ÿ�̹� ����")]
    public float minSpawnInterval = 0.5f;
    public float maxSpawnInterval = 2.0f;

    [Header("���� ���� Ȯ�� ����")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;

    public float timer = 0.0f;
    public float nextSpawnTIme;

    // Start is called before the first frame update
    void Start()
    {
        SetNextSpawnTIme();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTIme)
        {
            SpawnObject();
            timer = 0.0f;
            SetNextSpawnTIme();
        }
    }

    void SpawnObject()
    {
        Transform spawnTransform = transform;

        int randomValue = Random.Range(0, 100);
        if (randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {
            Instantiate(MisslePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
    }

    void SetNextSpawnTIme()
    {

        nextSpawnTIme = Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
