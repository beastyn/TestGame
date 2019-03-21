using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс для спавна врагов
public class EnemySpawner : MonoBehaviour {
    [SerializeField] Transform enemyPrefab;
    [SerializeField] float minEnemyPositionX = -6f;
    [SerializeField] float maxEnemyPositionX = 6f;
    [SerializeField] float startEnemySpawnTime = 2f; //TODO сделаем как-нибудь уровни сложности

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();    }

    void Start ()
    {
        //запускаем корутину спавна врагов
        StartCoroutine(SpawnEnemy());
    }

    //бесконечно спавним врагов в заданных координатах с поворотом из префаба
    IEnumerator SpawnEnemy()
    {
        //проверяем статус игры, не спавним, если игрок "ой, всё"
        while (gameManager.GetGameStatus() != 0)
        {
            float enemyPositionX = Random.Range(minEnemyPositionX, maxEnemyPositionX);
            Vector3 enemyPosition = new Vector3(enemyPositionX, transform.position.y, 0);
            Instantiate(enemyPrefab, enemyPosition, enemyPrefab.transform.rotation, this.transform);

            yield return new WaitForSeconds(startEnemySpawnTime);
        }
    }
}
