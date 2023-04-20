using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverScript : MonoBehaviour
{
    [SerializeField] protected float minMoveSpeed = 4.0f;
    [SerializeField] protected float maxMoveSpeed = 6.0f;
    [SerializeField] protected float deadZone = -10.0f;
    [SerializeField] protected float rangeSpawnDistance = 5.0f;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomStartingPostion = new Vector3 (
            transform.position.x + Random.Range(-rangeSpawnDistance, rangeSpawnDistance),
            transform.position.y,
            transform.position.z);
        transform.position = randomStartingPostion;
        velocity = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * velocity) * Time.deltaTime;
        if (transform.position.y < deadZone)
        {
            Debug.Log("Platform deleted");
            Destroy(gameObject);
        }
    }
}
