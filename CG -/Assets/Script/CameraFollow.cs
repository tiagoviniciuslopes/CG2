using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;
    float speed = 0.125f;
    [SerializeField]
    Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
