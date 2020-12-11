using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public static float offsetX;

    private void Start()
    {
    }

    private void Update()
    {
        if (Player.Instance != null)
        {
            MoveTheCamera();
        }
    }

    private void MoveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = Player.Instance.transform.position.x + offsetX;
        transform.position = temp;
    }
}
