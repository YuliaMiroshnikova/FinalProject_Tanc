
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public GameObject explosionFX;
    public GameObject targetDamagedFX;
    public float explosionForce = 1000f;
    public float explosionRadius = 10f;
    public AudioSource audio;
    public AudioClip explosionSound, cubes;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        Vector3 explosionPoint = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
        foreach (var hit in colliders)
        {
            
            if (hit.CompareTag("Targets") && gameObject != null)
            {
                if (audio != null && cubes != null && !audio.isPlaying)
                {
                    audio.clip = cubes;
                    audio.Play();
                }
                Destroy(gameObject, cubes.length);
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    ContactPoint contact = other.contacts[0];
                    rb.AddExplosionForce(explosionForce, explosionPoint, explosionRadius);
                    GameObject explosionFXInstance = Instantiate(targetDamagedFX, contact.point, Quaternion.identity);
                }
            }
        }

        
        
        if (other.gameObject.CompareTag("Ground") && gameObject != null)
        {
            if (audio != null && explosionSound != null && !audio.isPlaying)
            {
                audio.clip = explosionSound;
                audio.Play();
            }

            Destroy(gameObject, explosionSound.length);
            
            if (other.contacts.Length > 0)
            {
                ContactPoint contact = other.contacts[0];  // точка контакта с коллайдером
                
                GameObject explosionFXInstance = Instantiate(explosionFX, contact.point, Quaternion.identity);
                Destroy(explosionFXInstance, 3f); 
            }
        }
    
    }

}
