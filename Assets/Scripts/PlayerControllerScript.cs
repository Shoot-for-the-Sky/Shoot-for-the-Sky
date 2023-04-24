using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] protected float speed = 10.0f;
    [SerializeField] protected float loseCameraAxisYDelta = 10.0f;
    [SerializeField] private GameObject mainCamera;
    public LogicManagerScript logicManagerScript;
    private Rigidbody2D rb;
    private float moveX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logicManagerScript = GameObject.FindGameObjectWithTag("LogicManagerScript").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        if(transform.position.y < mainCamera.transform.position.y - loseCameraAxisYDelta)
        {
            logicManagerScript.gameOver();
            this.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
}
