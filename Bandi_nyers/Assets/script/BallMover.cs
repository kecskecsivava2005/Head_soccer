using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 75f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(movement, 0, 0);
    }
}
