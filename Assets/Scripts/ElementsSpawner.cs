using UnityEngine;

public class RandomElementSpawner : MonoBehaviour
{
    // The prefab of the element to spawn
    public GameObject elementToSpawn;

    void Start()
    {
        // Invoke the "SpawnRandomElement" function every 5 seconds, starting 1 second after the script is run
        InvokeRepeating("SpawnRandomElement", 1f, 5f);

        
    }

    void SpawnRandomElement()
    {
        // Generate random positions for the element to spawn within a specified range
        float randomX = Random.Range(-20f, 8f);
        float randomY = Random.Range(-20f, 5f);
        float randomZ = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Create an instance of the "elementToSpawn" object at the randomly generated position
        Instantiate(elementToSpawn, spawnPosition, Quaternion.identity);
    }

} 