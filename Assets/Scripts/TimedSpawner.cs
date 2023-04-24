using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject perfabToSpawn;
    [SerializeField] protected float minSecondsBetweenSpawns = 0.5f;
    [SerializeField] protected float maxSecondsBetweenSpawns = 0.8f;
    [SerializeField] protected float distanceAbovePlayer = 10.0f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float maxAboveDistance = Mathf.Max(player.transform.position.y, mainCamera.transform.position.y);
            float newY = transform.position.y + maxAboveDistance + distanceAbovePlayer;
            Vector3 newPostition = new Vector3 (transform.position.x, newY, transform.position.z);

            Instantiate(perfabToSpawn, newPostition, Quaternion.identity);
            float secondsBetweenSpawns = Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
