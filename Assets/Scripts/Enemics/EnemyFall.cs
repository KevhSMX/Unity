using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform player;
    public float spawnRate = 2f;
    public float heightOffset = 7f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("SpawnAbove", 0.5f, spawnRate);
    }

    void SpawnAbove()
    {
        if (player != null)
        {
            Vector3 spawnPos = new Vector3(player.position.x, player.position.y + heightOffset, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}