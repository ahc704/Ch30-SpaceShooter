using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamicallly")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    [HideInInspector]
    public bool offRight , offLeft , offUp , offDown;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if(pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius);
            isOnScreen = false;
            offRight = true;
        }

        if(pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }

        if (pos.y > camWidth - radius)
        {
            pos.y = camWidth - radius);
            isOnScreen = false;
            offUp = true;
        }

        if (pos.y < -camWidth + radius)
        {
            pos.y = -camWidth + radius;
            isOnScreen = false;
            offDown = true;
        }

        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }

        transform.position = pos;
    }
}
