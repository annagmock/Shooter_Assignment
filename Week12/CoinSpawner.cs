using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 5f; // every 5 seconds
    public float coinLifetime = 3f;  // stays for 3 seconds
    public float xRange = 8f;        // adjust for your screen width
    public float yRange = 4f;        // adjust for your screen height

    void Start()
    {
        InvokeRepeating("SpawnCoin", 2f, spawnInterval); // start spawning after 2s
    }

    void SpawnCoin()
    {
        // pick a random position
        Vector2 randomPos = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));

        // spawn the coin
        GameObject coin = Instantiate(coinPrefab, randomPos, Quaternion.identity);

        // destroy it after a few seconds
        Destroy(coin, coinLifetime);
    }
}
