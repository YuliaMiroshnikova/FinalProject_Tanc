using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootingEffect;
    public Transform bulletSpawnPoint;
    public float shootingForce = 1000f;
    public float recoilForce = 100f;
    private Rigidbody _tank;
    private Vector3 currentRotation;
    


    void Start()
    {
        _tank = GetComponentInParent<Rigidbody>();
    }


    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bulletSpawned = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        GameObject explosionFX = Instantiate(shootingEffect, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bulletSpawned.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * shootingForce);


        // отдача
        if (_tank != null)
        {
            _tank.AddForce(-bulletSpawnPoint.forward * recoilForce, ForceMode.Impulse);
        }

        // Уничтожаем эффект взрыва после его проигрывания
        Destroy(explosionFX, 3f); // Предполагается, что эффект длится около 1 секунды
    }
    
}
