using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnEnemy;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform _playerTarget;

    private void Start()
    {
        StartCoroutine(CourutineSpawnEnemy());
    }

    private void Update()
    {

    }

    private IEnumerator CourutineSpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        int NumberRandom = Random.Range(0, 1);
        GameObject newEnemy = Instantiate(spawnEnemy[NumberRandom]);
        newEnemy.transform.position = spawnPoints[0].transform.position;
        newEnemy.GetComponent<PathFindingEnemy>().SetTagetPlayer(_playerTarget);
        StartCoroutine(CourutineSpawnEnemy());
    }
}
