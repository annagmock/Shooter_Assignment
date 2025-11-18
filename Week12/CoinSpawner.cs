using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;    
    public int coinsPerSpawn = 3;    
    public float spawnInterval = 2f; 
    public float minX = -8f;         
    public float maxX = 8f;          
    public float spawnY = 6f;       

    void Start()
    {
        StartCoroutine(SpawnCoinsRoutine());
    }

    IEnumerator SpawnCoinsRoutine()
    {
        while(true)
        {
            for (int i = 0; i < coinsPerSpawn; i++)
            {
                
                float randomX = Random.Range(minX, maxX);  
                Vector3 spawnPos = new Vector3(randomX, spawnY, 0); // Y stays the same

                Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
