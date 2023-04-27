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
    private bool moveRightDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logicManagerScript = GameObject.FindGameObjectWithTag("LogicManagerScript").GetComponent<LogicManagerScript>();
        moveRightDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        CheckDirection();
        ChangePlayerDirection();
        bool playerOutOfScreen = transform.position.y < mainCamera.transform.position.y - loseCameraAxisYDelta;
        if (playerOutOfScreen)
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

    void CheckDirection()
    {
        float currentMoveX = Input.GetAxis("Horizontal");
        if (currentMoveX < moveX)
        {
            moveRightDirection = true;
        } else
        {
            moveRightDirection = false;
        }
    }

    void ChangePlayerDirection()
    {
        if (moveRightDirection)
        {
            Vector3 newScale = new Vector3(-1, 1, 1);
            gameObject.transform.localScale = newScale;
        }
        else
        {
            Vector3 newScale = new Vector3(1, 1, 1);
            gameObject.transform.localScale = newScale;
        }
    }
}
