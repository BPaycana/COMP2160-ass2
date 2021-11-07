using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    public Transform target; // child object of your car
    public float distance = 20.0f; // distance of camera from car
    public float height = 5.0f; // Camera height
    public float heightDamping = 2.0f; // smoothness
    public float xOffset = 0;
    public float lookH = 0.0f;
    public Rigidbody parentRigidbody; // Car
    public float rotationSnapTime = 0.3F;
    public float distanceSnapTime;

    public float distanceMultiplier;
    private Vector3 lookV; // vector of camera 
    private float usedDistance; // previous distance
    float targetRotationAngle;

    float targetHeight;
    float currentRotationAngle;

    float currentHeight;
    Quaternion currentRotation;

    Vector3 targetPosition;
    private float yVelocity = 0.0F;

    private float zVelocity = 0.0F;
    void Start()

    {
        lookV = new Vector3(0, lookH, 0);




    }
    void LateUpdate()

    {
        targetHeight = target.position.y + height; // height the camerea will be is equal to the height of car plus height set for the camera

        currentHeight = transform.position.y; // setting current height of camera



        targetRotationAngle = target.eulerAngles.y;

        currentRotationAngle = transform.eulerAngles.y;
        currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, targetRotationAngle, ref yVelocity, rotationSnapTime); // using smooth angle between rotations, combined with distance below
        currentHeight = Mathf.Lerp(currentHeight, targetHeight, heightDamping * Time.deltaTime); // used to get difference between current distance from car and needed distance, then smoothed over Time.delta
        targetPosition = target.position;

        targetPosition.y = currentHeight; // set target height to current height

        targetPosition.x = target.position.x + xOffset;
        usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime);
        targetPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance); // adding to the vector of the camera, minus where it has been
        transform.position = targetPosition; // position of camera is now target of camera
        transform.LookAt(target.position + lookV); // look at the target (car) plus vector of camera
    }

}