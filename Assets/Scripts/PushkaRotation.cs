using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushkaRotation : MonoBehaviour
{
    public float mouseSpeed = 100f;
    private Vector3 currentRotation;
    private Vector3 initialRotation;
    
    
    private void Start()
    {
        currentRotation = transform.localEulerAngles;
        initialRotation = currentRotation;
    }
    
    void FixedUpdate()
    {
        RotatePushka();
    }

    private void RotatePushka()
    {
        float mouseX = (Input.mousePosition.x - Screen.width / 2) / Screen.width;
        float mouseY = (Input.mousePosition.y - Screen.height / 2) / Screen.height;

        // текущее вращение камеры
        currentRotation.z += mouseX * mouseSpeed * Time.deltaTime; // по z
        currentRotation.x -= mouseY * mouseSpeed * Time.deltaTime; // по y

        // ограничение углов
        // по y
        currentRotation.x = Mathf.Clamp(currentRotation.x, initialRotation.x - 10f, initialRotation.x + 15f);
        // по z
        currentRotation.z = Mathf.Clamp(currentRotation.z, initialRotation.z - 30f, initialRotation.z + 30f);

        transform.localEulerAngles = new Vector3(currentRotation.x, 0, currentRotation.z);
    }
}
