﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;

    [Header("Set Dynamicallly")]
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    
    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if(pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius);
        }

        if(pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
        }

        if (pos.y > camWidth - radius)
        {
            pos.y = camWidth - radius);
        }

        if (pos.y < -camWidth + radius)
        {
            pos.y = -camWidth + radius;
        }

        transform.position = pos;
    }
}
