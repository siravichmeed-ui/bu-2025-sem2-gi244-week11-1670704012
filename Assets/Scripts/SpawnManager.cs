using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("Prefabs")]
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    [System.Serializable]
    public class Wave
    {
        public int totalSpawnEnemies;
        public int numberOfRandomSpawnPoint;
        public float delayStart;
        public float spawnInterval;
        public int numberOfPowerUp;
    }

    [Header("Waves")]
    public Wave[] waves;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        for (int w = 0; w < waves.Length; w++)
        {
            Wave wave = waves[w];

            Debug.Log("Start Wave " + (w + 1));

            //Spawn PowerUp ก่อนเริ่ม wave
            for (int i = 0; i < wave.numberOfPowerUp; i++)
            {
                SpawnPowerUp();
            }

           
            yield return new WaitForSeconds(wave.delayStart);

            
            for (int i = 0; i < wave.totalSpawnEnemies; i++)
            {
                SpawnEnemy(wave.numberOfRandomSpawnPoint);
                yield return new WaitForSeconds(wave.spawnInterval);
            }

            
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);

            Debug.Log("End Wave " + (w + 1));
        }

        Debug.Log("All Waves Complete!");
    }

    void SpawnEnemy(int randomPointCount)
    {
        // จำกัดจำนวน spawn point ที่ใช้
        int max = Mathf.Min(randomPointCount, spawnPoints.Length);

        int index = Random.Range(0, max);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    void SpawnPowerUp()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);
    }
}