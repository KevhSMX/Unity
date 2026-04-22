using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform player;
    public float spawnRate = 2f;
    public float heightOffset = 7f;

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform; //Accedeix a la pos del jugador

        InvokeRepeating("SpawnAbove", 0.5f, spawnRate); //Crida a la funció SpawnAbove i comença 
    }

    void SpawnAbove()
    {
        if (player != null) //Mira si el jugador es o no
        {
            Vector3 spawnPos = new Vector3(player.position.x, player.position.y + heightOffset, 0); //Busca la pos del jugador
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity); //Instancia el prefab del enemic
        }
    }
}
