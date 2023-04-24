using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] protected float cameraAxisYDelta = 3.0f;
    public Transform target;

    private void LateUpdate()
    {
        float targetAxisY = target.position.y - cameraAxisYDelta;
        if (targetAxisY > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, targetAxisY, transform.position.z);
            transform.position = newPosition;
        }
    }
}
