using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float xOffset, yOffset, zOffset;

    void Update()
    {
        SetPlayerOffsetPosition();
    }

    void SetPlayerOffsetPosition()
    {
        transform.position = playerTransform.position + new Vector3(xOffset, yOffset, zOffset);
    }
}
