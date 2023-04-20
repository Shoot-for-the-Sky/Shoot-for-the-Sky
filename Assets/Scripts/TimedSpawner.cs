using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject perfabToSpawn;
    [SerializeField] protected float minSecondsBetweenSpawns = 0.5f;
    [SerializeField] protected float maxSecondsBetweenSpawns = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(perfabToSpawn, transform.position, Quaternion.identity);
            float secondsBetweenSpawns = Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
