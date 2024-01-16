using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleTurn : MonoBehaviour
{
    public Transform rotationCenter; // Assign this to the empty GameObject
    public float speed = 100f;

    void Update()
    {
        // Rotate around 'rotationCenter' at 'speed' degrees per second.
        transform.RotateAround(rotationCenter.position, Vector3.forward, speed * Time.deltaTime);
    }
}