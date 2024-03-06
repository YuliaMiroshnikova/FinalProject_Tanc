
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float mouseSpeed = 100f;
    private Vector2 currentRotation;
    private Vector2 initialRotation;
    
    private void Start()
    {
        currentRotation = transform.localEulerAngles;
        initialRotation = currentRotation;
    }
    
    void FixedUpdate()
    {
        CameraRotation();
    }
    
    // с таким подходом камера вращается более плавно, мне понравилось,
    // плюс при возвращении курсора в центр экрана камера возвращается в исходное направление взгляда
    private void CameraRotation()
    {
        Camera cam = transform.GetChild(0)?.GetComponent<Camera>();
        if (cam == null) return;

        float mouseX = (Input.mousePosition.x - Screen.width / 2) / Screen.width;
        float mouseY = (Input.mousePosition.y - Screen.height / 2) / Screen.height;

        // текущее вращение камеры
        currentRotation.y += mouseX * mouseSpeed * Time.deltaTime;
        currentRotation.x -= mouseY * mouseSpeed * Time.deltaTime;

        // ограничение углов
        currentRotation.x = Mathf.Clamp(currentRotation.x, initialRotation.x - 10f, initialRotation.x + 15f);
        currentRotation.y = Mathf.Clamp(currentRotation.y, initialRotation.y - 30f, initialRotation.y + 30f);

        cam.transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, 0f);

    }
}
