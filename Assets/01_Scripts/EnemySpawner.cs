using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyPrefabs;
    public Player player;
    public SoundPlayer soundPlayer;

    public float spawnTime = 1f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Enemy enemy = Instantiate(enemyPrefabs[randomIndex], transform.position, transform.rotation);
        enemy.player = player;
        enemy.soundPlayer = soundPlayer;
    }
}
