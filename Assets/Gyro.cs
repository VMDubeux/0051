using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    public float angleX;
    public float angleZ;
    public float MinAngleY;
    public float MaxAngleY;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        Vector3 previousEulerAngles = transform.eulerAngles;
        Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;

        float rotationScale = 0.1f;

        Vector3 targetEulerAngles = previousEulerAngles + gyroInput * Time.deltaTime * Mathf.Rad2Deg * rotationScale;
        targetEulerAngles.x = angleX; // Only this line has been added
        targetEulerAngles.z = angleZ;

        targetEulerAngles.y = Mathf.Clamp(targetEulerAngles.y, MinAngleY,MaxAngleY);
        transform.eulerAngles = targetEulerAngles;
    }
}