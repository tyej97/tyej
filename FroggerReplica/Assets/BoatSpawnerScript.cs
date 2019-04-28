using UnityEngine;

public class BoatSpawnerScript : MonoBehaviour
{
    public float spawnDelay = .4f;

    public GameObject boat;
    public GameObject boat1;

    public Transform[] spawnPoints;

    float nextTimeToSpawn = 0f;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnBoat();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnBoat()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        if (randomIndex == 0 || randomIndex == 1)
            Instantiate(boat, spawnPoint.position, spawnPoint.rotation);
        else
            Instantiate(boat1, spawnPoint.position, spawnPoint.rotation);
    }
}
