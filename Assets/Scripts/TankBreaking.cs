using UnityEngine;

public class TankBreaking : MonoBehaviour
{
    public float accelerateAngle = 10f;
    private Rigidbody _tankBody;
    
    
    
    void Awake()
    {
        _tankBody = GetComponentInParent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Acceleration();
    }

    private void Acceleration()
    {
        float vertMove = Input.GetAxis("Vertical");
        float speed = _tankBody.velocity.magnitude;
        float tiltAngle = 0f;
        
        if (vertMove != 0)
        {
            // разгон
            tiltAngle = -Mathf.Clamp(speed / accelerateAngle, 0f, accelerateAngle); 
            Quaternion tiltRotation = Quaternion.AngleAxis(tiltAngle * 2, Vector3.right);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, tiltRotation, Time.fixedDeltaTime * 5f);
        }
        else if (vertMove == 0)
        {
            // торможение
            tiltAngle = Mathf.Clamp(speed / accelerateAngle, 0f, accelerateAngle);
            Quaternion tiltRotation = Quaternion.AngleAxis(tiltAngle * 4, Vector3.right);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, tiltRotation, Time.fixedDeltaTime * 5f);
        }
    }
}


