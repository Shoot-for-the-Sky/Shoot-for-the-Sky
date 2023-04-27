using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoverScript : MonoBehaviour
{
    [SerializeField] protected float minMoveSpeed = 2.0f;
    [SerializeField] protected float maxMoveSpeed = 3.0f;
    [SerializeField] protected float deadZone = -10.0f;
    [SerializeField] protected float rangeSpawnDistance = 5.0f;
    [SerializeField] protected float jumpForce = 10.0f;
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
        GameObject mainCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        bool PlatformOutOfDeadZone = transform.position.y < mainCamera.transform.position.y + deadZone;
        if (PlatformOutOfDeadZone)
        {
            Debug.Log("Platform deleted");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
