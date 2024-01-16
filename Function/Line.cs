using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 5f;
    private float originalPositionX;
    private bool isMovingRight = true;

    void Start()
    {
        originalPositionX = transform.position.x;
    }

    void Update()
    {
        // Calculate the target position
        float targetPositionX = transform.position.x + (isMovingRight ? moveSpeed * Time.deltaTime : -moveSpeed * Time.deltaTime);

        // Move the line to the target position
        transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);

        // Check if the line has reached the leftmost or rightmost position
        if ((isMovingRight && targetPositionX > originalPositionX + moveDistance) || (!isMovingRight && targetPositionX < originalPositionX - moveDistance))
        {
            // Flip the direction
            isMovingRight = !isMovingRight;
        }
    }
}